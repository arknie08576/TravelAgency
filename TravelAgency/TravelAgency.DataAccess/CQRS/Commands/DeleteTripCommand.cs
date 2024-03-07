using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class DeleteTripCommand : CommandBase<Trip, Trip>
    {
        public int Id { get; set; }
        public override async Task<Trip> Execute(TravelAgencyContex contex)
        {
            var trip = await contex.Trips.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (trip != null)
            {
                contex.Trips.Remove(trip);
            }
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
