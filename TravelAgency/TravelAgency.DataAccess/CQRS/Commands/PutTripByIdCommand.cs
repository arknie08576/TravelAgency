using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class PutTripByIdCommand : CommandBase<Trip, Trip>
    {

        public override async Task<Trip> Execute(TravelAgencyContex contex)
        {
            var trip = await contex.Trips.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
            contex.Trips.Remove(trip);
            await contex.Trips.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
