using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataAccess
{
    public class TravelAgencyContexFactory : IDesignTimeDbContextFactory<TravelAgencyContex>
    {
        public TravelAgencyContex CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelAgencyContex>();
            optionsBuilder.UseSqlServer("Server=tcp:travel-agency.database.windows.net,1433;Initial Catalog=TravelAgencyStorage;Persist Security Info=False;User ID=arknie08576;Password=aArkus14;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new TravelAgencyContex(optionsBuilder.Options);
        }
    }
}
