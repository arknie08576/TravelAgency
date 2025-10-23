using Bogus;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography;
using TravelAgency.DataAccess.Entities;

namespace YourNamespace;

public static class DbSeeder
{
    // Wywołanie: await DbSeeder.SeedAsync(context);
    public static async Task SeedAsync(DbContext db,
        int usersCount = 60, int tripsCount = 90, int reservationsCount = 220, double opinionShare = 0.55)
    {
        // Jeśli już coś jest – nie seedujemy drugi raz
        var hasAny = await db.Set<User>().AsNoTracking().AnyAsync()
                    || await db.Set<Trip>().AsNoTracking().AnyAsync()
                    || await db.Set<Reservation>().AsNoTracking().AnyAsync()
                    || await db.Set<Opinion>().AsNoTracking().AnyAsync();

        if (hasAny) return;

        // --- Słowniki / zbiory referencyjne ---
        var pl = new CultureInfo("pl-PL");
        Randomizer.Seed = new Random(12345); // deterministycznie

        // kraje/miasta + typowe wyjazdy z PL
        var destinations = new (string Country, string City)[]
        {
            ("Hiszpania","Barcelona"), ("Hiszpania","Majorka"), ("Hiszpania","Teneryfa"),
            ("Grecja","Ateny"), ("Grecja","Santorini"), ("Grecja","Kreta"),
            ("Włochy","Rzym"), ("Włochy","Neapol"), ("Włochy","Sycylia"),
            ("Portugalia","Lizbona"), ("Portugalia","Porto"),
            ("Francja","Paryż"), ("Cypr","Larnaka"), ("Turcja","Antalya"),
            ("Egipt","Hurghada"), ("Egipt","Marsa Alam"),
        };

        var departures = new[] { "Warszawa (WAW)", "Kraków (KRK)", "Gdańsk (GDN)", "Wrocław (WRO)", "Poznań (POZ)", "Katowice (KTW)" };
        var foods = new[] { "All Inclusive", "HB (śniadanie+obiadokolacja)", "BB (tylko śniadanie)", "SC (bez wyżywienia)" };
        var hotels = new[]
        {
            "Grand Plaza", "Sea Breeze Resort", "City Center Inn", "Riviera Palace",
            "Boutique Corner", "Skyline Hotel", "Old Town Suites", "Sunset Bay", "Blue Lagoon", "Royal Gardens"
        };

        string DocsFor(string country) =>
            country is "Egipt" or "Turcja"
            ? "Paszport (min. 6 mies. ważności), wiza (jeśli wymagana)"
            : "Dowód osobisty lub paszport (UE/Schengen)";

        // --- Generatory Bogus ---
        string password = "12345";

        // generate a 128-bit salt using a secure PRNG
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

        // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        //Console.WriteLine($"Hashed: {hashed}");
        password = Convert.ToBase64String(salt) + ";" + hashed;
        // Użytkownicy
        var userFaker = new Faker<User>("pl")
            .RuleFor(u => u.Name, f => f.Name.FirstName())
            .RuleFor(u => u.Surname, f => f.Name.LastName())
            .RuleFor(u => u.Login, (f, u) =>
            {
                var baseLogin = $"{ToSlug(u.Name)}.{ToSlug(u.Surname)}";
                return $"{baseLogin}{f.Random.Int(10, 999)}";
            })
            // Hasło jako hash-udawacz (nie trzymaj plaintextu w realu)
            .RuleFor(u => u.Password, password) // „bcrypt-like” 60 znaków
            .RuleFor(u => u.Email, (f, u) => $"{ToSlug(u.Name)}.{ToSlug(u.Surname)}{f.Random.Int(10, 999)}@example.com")
            .RuleFor(u => u.Role, f => f.Random.Bool(0.1f) ? UserRole.admin : UserRole.user);

        var users = userFaker.Generate(usersCount);
        // dopilnuj unikalności email/login
        users = users
            .GroupBy(u => u.Email)
            .SelectMany(g => g.Select((u, idx) => { if (idx > 0) u.Email = u.Email.Replace("@", $"+{idx}@"); return u; }))
            .GroupBy(u => u.Login)
            .SelectMany(g => g.Select((u, idx) => { if (idx > 0) u.Login = $"{u.Login}{idx}"; return u; }))
            .ToList();

        // Wycieczki
        var today = DateOnly.FromDateTime(DateTime.UtcNow.Date);
        var tripFaker = new Faker<Trip>("pl")
            .RuleFor(t => t.HotelName, f => f.PickRandom(hotels))
            .RuleFor(t => t.HotelDescription, f => f.Lorem.Paragraphs(1, 2))
            .RuleFor(t => t.Country, f => f.PickRandom(destinations).Country)
            .RuleFor(t => t.City, (f, t) =>
            {
                // dopasuj miasto do kraju
                var cities = destinations.Where(d => d.Country == t.Country).Select(d => d.City).ToArray();
                return f.PickRandom(cities);
            })
            .RuleFor(t => t.Departure, f => f.PickRandom(departures))
            .RuleFor(t => t.Food, f => f.PickRandom(foods))
            .RuleFor(t => t.RequiredDocuments, (f, t) => DocsFor(t.Country))
            .RuleFor(t => t.PricePerAdult, f => f.Random.Int(1600, 5200)) // PLN za osobę dorosłą
            .RuleFor(t => t.PricePerKid, (f, t) => (int)Math.Round(t.PricePerAdult * f.Random.Double(0.45, 0.7)))
            .RuleFor(t => t.StartDate, f =>
            {
                // część ofert w przyszłości (sprzedaż), część w przeszłości (do opinii)
                var biasFuture = f.Random.Bool(0.65f);
                return biasFuture
                    ? today.AddDays(f.Random.Int(7, 150))
                    : today.AddDays(-f.Random.Int(15, 120));
            })
            .RuleFor(t => t.StopDate, (f, t) =>
            {
                var length = f.Random.Int(4, 10); // 4–10 nocy
                return t.StartDate.AddDays(length);
            });

        var trips = tripFaker.Generate(tripsCount);

        // Rezerwacje
        var resFaker = new Faker<Reservation>("pl")
            .RuleFor(r => r.Trip, f => f.PickRandom(trips))
            .RuleFor(r => r.TripId, (f, r) => r.Trip.Id) // EF i tak nadpisze
            .RuleFor(r => r.User, f => f.PickRandom(users))
            .RuleFor(r => r.UserId, (f, r) => r.User.Id)
            .RuleFor(r => r.AdultsNumber, f => f.Random.Int(1, 2))
            .RuleFor(r => r.KidsNumber, f => f.Random.Int(0, 2))
            .RuleFor(r => r.PricePaid, (f, r) =>
            {
                var basePrice = r.AdultsNumber * r.Trip.PricePerAdult + r.KidsNumber * r.Trip.PricePerKid;
                // czasem rabat first/last minute 0–12%
                var discount = f.Random.Double(0.00, 0.12);
                return (int)Math.Round(basePrice * (1 - discount), MidpointRounding.AwayFromZero);
            });

        var reservations = resFaker.Generate(reservationsCount);

        // Opinie — tylko do wyjazdów, które już się zakończyły
        var endedReservations = reservations.Where(r => r.Trip.StopDate <= today).ToList();
        var opinionsCount = (int)Math.Round(endedReservations.Count * opinionShare);

        var opinionFaker = new Faker<Opinion>("pl")
            .RuleFor(o => o.Reservation, f => f.PickRandom(endedReservations))
            .RuleFor(o => o.ReservationId, (f, o) => o.Reservation.Id)
            .RuleFor(o => o.Rating, f => f.Random.WeightedRandom(new[] { 3, 4, 5 }, new[] { 1f, 3f, 5f })) // Ensure weights are double
            .RuleFor(o => o.Description, (f, o) =>
            {
                var good = new[]
                {
                    "Świetna organizacja, hotel zgodny z opisem.",
                    "Wszystko na plus: jedzenie, obsługa, przeloty.",
                    "Bardzo dobry stosunek jakości do ceny.",
                    "Czysty hotel, rewelacyjna lokalizacja.",
                };
                var mixed = new[]
                {
                    "Ok, ale transfer mógłby być lepiej zorganizowany.",
                    "Pokój mniejszy niż na zdjęciach, ale czysty.",
                    "Fajne wycieczki fakultatywne, jedzenie przeciętne.",
                };
                var bad = new[]
                {
                    "Hałas w nocy, słaba klimatyzacja.",
                    "Opóźniony lot i przeciętne jedzenie w hotelu.",
                };
                return o.Rating switch
                {
                    >= 5 => f.PickRandom(good),
                    4 => f.PickRandom(good.Concat(mixed).ToArray()),
                    3 => f.PickRandom(mixed.Concat(bad).ToArray()),
                    _ => f.PickRandom(bad)
                };
            })
            .RuleFor(o => o.Date, (f, o) =>
            {
                // kilka dni po powrocie
                var min = o.Reservation.Trip.StopDate.AddDays(1);
                var max = o.Reservation.Trip.StopDate.AddDays(30);
                return DateOnly.FromDateTime(f.Date.Between(min.ToDateTime(TimeOnly.MinValue),
                                                            max.ToDateTime(TimeOnly.MinValue)));
            });

        // aby zachować 1:1 (jedna opinia na rezerwację), wybierz unikalne rezerwacje:
        var uniqueReviewed = endedReservations.OrderBy(_ => Guid.NewGuid()).Take(opinionsCount).ToList();
        var opinions = new List<Opinion>(opinionsCount);
        foreach (var res in uniqueReviewed)
        {
            var op = opinionFaker.Generate();
            op.Reservation = res;
            op.ReservationId = res.Id;
            opinions.Add(op);
        }

        // --- Persist ---
        await db.Set<User>().AddRangeAsync(users);
        await db.Set<Trip>().AddRangeAsync(trips);
        await db.Set<Reservation>().AddRangeAsync(reservations);
        await db.SaveChangesAsync(); // zapisz, by mieć Id-ki

        if (opinions.Count > 0)
        {
            await db.Set<Opinion>().AddRangeAsync(opinions);
            await db.SaveChangesAsync();
        }
    }

    private static string ToSlug(string s)
    {
        s = s.Trim().ToLowerInvariant();
        s = s.Replace('ą', 'a').Replace('ć', 'c').Replace('ę', 'e').Replace('ł', 'l')
             .Replace('ń', 'n').Replace('ó', 'o').Replace('ś', 's').Replace('ż', 'z').Replace('ź', 'z');
        var chars = s.Where(ch => char.IsLetterOrDigit(ch) || ch == '.').ToArray();
        return new string(chars);
    }
}
