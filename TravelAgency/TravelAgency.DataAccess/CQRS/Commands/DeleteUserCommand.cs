using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class DeleteUserCommand : CommandBase<User, User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(TravelAgencyContex contex)
        {
            var user = await contex.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            if (user != null)
            {
                contex.Users.Remove(user);
            }
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
