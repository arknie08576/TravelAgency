using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class AddOpinionCommand : CommandBase<Opinion, Opinion>
    {
        public override async Task<Opinion> Execute(TravelAgencyContex contex)
        {
            await contex.Opinions.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
