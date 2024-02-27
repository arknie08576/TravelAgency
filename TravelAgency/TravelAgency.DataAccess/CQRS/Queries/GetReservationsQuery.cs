using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetReservationsQuery : QueryBase<List<Reservation>>
    {
        public int Id { get; set; }
        public override async Task<List<Reservation>> Execute(TravelAgencyContex contex)
        {
            var reservations = await contex.Reservations.ToListAsync();

            return reservations;
        }
    }
}
