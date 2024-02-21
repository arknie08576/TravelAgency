using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess
{
    public class TravelAgencyContex : DbContext
    {
        public TravelAgencyContex(DbContextOptions<TravelAgencyContex> options) : base(options) { 
       
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
