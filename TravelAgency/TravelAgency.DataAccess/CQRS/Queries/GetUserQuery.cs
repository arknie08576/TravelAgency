using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public string Login {  get; set; }
        // public int Rating { get; set; }
        public override async Task<User> Execute(TravelAgencyContex contex)
        {
            var user = await contex.Users.FirstOrDefaultAsync(x => x.Login == this.Login);
            
            return user;
        }
    }
}
