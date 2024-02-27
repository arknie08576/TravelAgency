using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class DeleteReservationCommand : CommandBase<Reservation, Reservation>
    {
        public int Id { get; set; }
        public override async Task<Reservation> Execute(TravelAgencyContex contex)
        {
            var reservation = await contex.Reservations.FirstOrDefaultAsync(x => x.Id == this.Id);
            contex.Reservations.Remove(reservation);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
