using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class PutUserByIdCommand : CommandBase<User, User>
    {

        public override async Task<User> Execute(TravelAgencyContex contex)
        {
            var user = await contex.Users.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
            contex.Users.Remove(user);
            await contex.Users.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
