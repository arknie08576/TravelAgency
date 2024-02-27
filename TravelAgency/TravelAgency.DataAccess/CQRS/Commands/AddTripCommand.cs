using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class AddTripCommand : CommandBase<Trip, Trip>
    {
        public override async Task<Trip> Execute(TravelAgencyContex contex)
        {
            await contex.Trips.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
