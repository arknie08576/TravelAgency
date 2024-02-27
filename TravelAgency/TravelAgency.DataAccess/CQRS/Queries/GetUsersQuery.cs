using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public int Id { get; set; }
        public override async Task<List<User>> Execute(TravelAgencyContex contex)
        {
            var users = await contex.Users.ToListAsync();

            return users;
        }
    }
}
