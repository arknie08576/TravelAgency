using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccess.Entities
{
    public class Trip : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string HotelName { get; set; }
        [Required]
        public string HotelDescription { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set;}
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public int PricePerAdult { get; set; }
        [Required]
        public int PricePerKid { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly StopDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string Departure { get; set; }
        [Required]
        [MaxLength(100)]
        public string Food { get; set; }
        [Required]
        [MaxLength(100)]
        public string RequiredDocuments { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
