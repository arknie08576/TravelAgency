using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetOpinionsQuery : QueryBase<List<Opinion>>
    {
        public int Id { get; set; }
        public override async Task<List<Opinion>> Execute(TravelAgencyContex contex)
        {
            var opinions = await contex.Opinions.ToListAsync();

            return opinions;
        }
    }
}
