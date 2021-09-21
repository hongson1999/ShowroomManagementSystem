using Server.Context;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShowroomDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Vehicles.Any())
            {
                return;   // DB has been seeded
            }

            // Create dump branchs
            var branches = new Branch[]
            {
                new Branch{Name="Lamborghini"}, // id = 1
                new Branch{Name="Mercedes"}, // id = 2
            };
            foreach (Branch b in branches)
            {
                context.Branches.Add(b);
            }
            context.SaveChanges();

            // Create dump vehicles
            var vehicles = new Vehicle[]
            {
                new Vehicle{ ModelNumber="asd", Name="asd", Price=12, BranchId=1},
            };
            foreach (Vehicle v in vehicles)
            {
                context.Vehicles.Add(v);
            }
            context.SaveChanges();
        }
    }
}
