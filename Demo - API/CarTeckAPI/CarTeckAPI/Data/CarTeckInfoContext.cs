using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarTeckAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarTeckAPI.Data
{
    public class CarTeckInfoContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
       // public DbSet<Seller> Sellers { get; set; }

        public CarTeckInfoContext(DbContextOptions<CarTeckInfoContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }           
    }
}
