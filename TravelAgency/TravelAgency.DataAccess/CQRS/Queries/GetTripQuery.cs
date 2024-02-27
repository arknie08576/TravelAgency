using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetTripQuery : QueryBase<Trip>
    {
        public int Id { get; set; }
        // public int Rating { get; set; }
        public override async Task<Trip> Execute(TravelAgencyContex contex)
        {
            var trip = await contex.Trips.FirstOrDefaultAsync(x => x.Id == this.Id);

            return trip;
        }
    }
}
