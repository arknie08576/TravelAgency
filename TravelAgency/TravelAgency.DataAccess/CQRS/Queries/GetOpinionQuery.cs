using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Queries
{
    public class GetOpinionQuery : QueryBase<Opinion>
    {
        public int Id { get; set; }
        public override async Task<Opinion> Execute(TravelAgencyContex contex)
        {
            var opinion = await contex.Opinions.FirstOrDefaultAsync(x=>x.Id == this.Id);

            return opinion;
        }
    }
}
