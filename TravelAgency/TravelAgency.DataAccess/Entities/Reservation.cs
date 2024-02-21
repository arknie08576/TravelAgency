using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccess.Entities
{
    public class Reservation : EntityBase
    {
        public int TripId {get; set;}
        public int UserId { get; set;}
        [Required]
        public int AdultsNumber { get; set; }
        [Required]
        public int KidsNumber { get; set;}
        [Required]
        public int PricePaid { get; set; }
        public Opinion Opinion { get; set; }
        [Required]
        public Trip Trip { get; set; }
        [Required]
        public User User { get; set; }
    }
}
