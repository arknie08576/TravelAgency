using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetTripsQuery : QueryBase<List<Trip>>
    {
        public int Id { get; set; }
        public override async Task<List<Trip>> Execute(TravelAgencyContex contex)
        {
            var trips = await contex.Trips.ToListAsync();

            return trips;
        }
    }
}
