using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ApplicationServices.API.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int AdultsNumber { get; set; }
        public int KidsNumber { get; set; }
        public int PricePaid { get; set; }
    }
}
