using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class AuthenticateMeQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        // public int Rating { get; set; }
        public override async Task<User> Execute(TravelAgencyContex contex)
        {
            var user = await contex.Users.FirstOrDefaultAsync(x => x.Login == this.Login);

            var username = Login;
            var password = Password;

            //user = await this.queryExecutor.Execute(query);

            // TODO: HASH!
            // Console.Write("Enter a password: ");
            var pwd = user.Password.Split(';');

            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            salt = Convert.FromBase64String(pwd[0]);
            // Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            // Console.WriteLine($"Hashed: {hashed}");
            password = hashed;
            if (user == null || pwd[1] != hashed)
            {
                return null;
            }
                return user;
        }
    }
}
