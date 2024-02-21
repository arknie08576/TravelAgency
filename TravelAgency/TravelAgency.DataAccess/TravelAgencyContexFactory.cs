﻿using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TEFRQV5\\SQLEXPRESS;Initial Catalog=TravelAgencyDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            return new TravelAgencyContex(optionsBuilder.Options);
        }
    }
}
