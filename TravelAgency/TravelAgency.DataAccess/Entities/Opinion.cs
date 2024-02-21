using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccess.Entities
{
    public class Opinion : EntityBase
    {
        public int ReservationId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public Reservation Reservation { get; set; }

    }
}
