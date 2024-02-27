using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetReservationQuery : QueryBase<Reservation>
    {
        public int Id { get; set; }
        // public int Rating { get; set; }
        public override async Task<Reservation> Execute(TravelAgencyContex contex)
        {
            var reservation = await contex.Reservations.FirstOrDefaultAsync(x => x.Id == this.Id);

            return reservation;
        }
    }
}
