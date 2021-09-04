using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarTeckAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarTeckAPI.Data
{
    public class SeedUserData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            CarTeckInfoContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CarTeckInfoContext>();
            //if (context.Database.GetService<IRelationalDatabaseCreator>().Exists())
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Users.Any())
            {
               context.Users.AddRange(
               new User
               {
                   UserName = "Gk",
                   Email = "test@user.be",
                   Password = "test",
                   BirthDate = new DateTime(1996, 12, 22)
               },
                new User
                {
                    UserName = "alfa",
                    Email = "alfa@user.be",
                    Password = "test123",
                    BirthDate = new DateTime(1996, 12, 22)
                });
                context.SaveChanges();
            }
           
            


        }
    }
}
