using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess.CQRS.Commands
{
    public class PutOpinionByIdCommand : CommandBase<Opinion, Opinion>
    {
        
        public override async Task<Opinion> Execute(TravelAgencyContex contex)
        {
            var opinion = await contex.Opinions.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
            contex.Opinions.Remove(opinion);
            await contex.Opinions.AddAsync(this.Parameter);
            await contex.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
