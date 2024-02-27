using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class PutReservationByIdCommand : CommandBase<Reservation, Reservation>
    {

        public override async Task<Reservation> Execute(TravelAgencyContex contex)
        {
            var reservation = await contex.Reservations.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
            contex.Reservations.Remove(reservation);
            await contex.Reservations.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
