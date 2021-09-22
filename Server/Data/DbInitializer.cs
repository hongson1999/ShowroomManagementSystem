using Server.Context;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Server.Extensions;
using System.Threading.Tasks;

namespace Server.Data
{
    public static class DbInitializer
    {
        public static IEnumerable<OrderDetail> OrderDetails { get; private set; }

        public static void Initialize(ShowroomDbContext context)
        {
            context.Database.EnsureCreated();

            var random = new Random();

            if (context.Vehicles.Any())
            {
                return;   // DB has been seeded
            }

            // Create dump branchs
            var branches = new Branch[]
            {
                new Branch{ Name="Lamborghini" }, // id = 1
                new Branch{ Name="Mercedes" }, // id = 2
                new Branch{ Name="BMW" }, // id = 3
                new Branch{ Name="Bentley" }, // id = 4
                new Branch{ Name="Rolls-Royce"}, // id = 5
                new Branch{ Name="Porsche" }, // id = 6
            };
            foreach (Branch b in branches)
            {
                context.Branches.Add(b);
            }
            context.SaveChanges();

            // Create dump vehicles
            var vehicles = new Vehicle[]
            {
                new Vehicle{ ModelNumber="Lamborghini Aventador", Name="Lamborghini", Price=90000, BranchId=1},
                new Vehicle{ ModelNumber="Mercedes maybach s650", Name="Mercedes", Price=45000, BranchId=2},
                new Vehicle{ ModelNumber="Bmw-i8", Name="BMW", Price=40000, BranchId=3},
                new Vehicle{ ModelNumber="Bentley continental gt", Name="Bentley", Price=70000, BranchId=4},
                new Vehicle{ ModelNumber="Rolls - Royce Phantom", Name="Rolls - Royce", Price=110000, BranchId=5},
                new Vehicle{ ModelNumber="Porsche Panamera", Name="Porsche", Price=65000, BranchId=6},
            };
            foreach (Vehicle v in vehicles)
            {
                context.Vehicles.Add(v);
            }
            context.SaveChanges();

            // Create dump customers
            var customers = new Customer[]
            {
                new Customer{ Name="Jonson", Address="1700 California Street, Suite 580, San Francisco, CA 94109", Phone= "0415-922-1707", Email="jonson@gmail.com"},
                new Customer{ Name="Peter", Address="100 Mile, Suite 520, Washington D.C, CA 94109", Phone= "0415-912-1707", Email="peter@gmail.com"},
                new Customer{ Name="Helen", Address="700 Blue Ridge Street, Suite 580, Texas, CA 94109", Phone= "0415-922-1707", Email="helen@gmail.com"},
                new Customer{ Name="Anna", Address="1500  Carolinas Street, Suite 580, Colorado, CA 94109", Phone= "0415-932-1707", Email="anna@gmail.com"},
                new Customer{ Name="Kali", Address="1400 Virginia Street, Suite 580, Massachusetts, CA 94109", Phone= "0415-942-1707", Email="kali@gmail.com"},
                new Customer{ Name="Bean", Address="1100 Lake Shore Street, Suite 580, Chicago, CA 94109", Phone= "0415-952-1707", Email="jonson@gmail.com"},
            };
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            // Create dump services
            var services = new Service[]
            {
                new Service{ Name= "Tire maintenance", SalePrice= 70},
                new Service{ Name= "Car wash", SalePrice= 10 },
                new Service{ Name= "Change oil", SalePrice= 30 },

            };
            foreach (Service s in services)
            {
                context.Services.Add(s);
            }
            context.SaveChanges();

            //Create dump showroom vehicles
            var showroomvehicles = new ShowroomVehicle[]
            {
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 100000, VehicleId= 1 },
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 65000, VehicleId= 2 },
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 90000, VehicleId= 3 },
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 95000, VehicleId= 4 },
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 130000, VehicleId= 5 },
                new ShowroomVehicle{ Id="showroom".GenerateRandomId(10) ,SalePrice= 80000, VehicleId= 6 },
            };
            foreach (ShowroomVehicle s in showroomvehicles)
            {
                context.ShowroomVehicles.Add(s);
            }
            context.SaveChanges();


            // Create dump warehouseVehicel
            var warehouseVehicles = new List<WarehouseVehicle>();
            foreach (ShowroomVehicle showroomVehicle in showroomvehicles)
            {
                warehouseVehicles.AddRange(new WarehouseVehicle[] {
                    new WarehouseVehicle{ Id="warehouse".GenerateRandomId(10), AllotDate=DateTime.Now, ShowroomVehicleId=showroomVehicle.Id, VehicleId=showroomVehicle.Vehicle.Id },
                    new WarehouseVehicle{ Id="warehouse".GenerateRandomId(10), AllotDate=DateTime.Now, ShowroomVehicleId=showroomVehicle.Id, VehicleId=showroomVehicle.Vehicle.Id  },
                    new WarehouseVehicle{ Id="warehouse".GenerateRandomId(10), AllotDate=DateTime.Now, ShowroomVehicleId=showroomVehicle.Id, VehicleId=showroomVehicle.Vehicle.Id  },
                });
            }
            foreach (WarehouseVehicle wv in warehouseVehicles)
            {
                context.WarehouseVehicles.Add(wv);
            }
            context.SaveChanges();

            //Create dump dealers
            var dealers = new Dealer[]
            {
                new Dealer{ UserName= "phu", Email="phu@gmail.com", Password = "123456".HashPasswordMD5(), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now  },
                new Dealer{ UserName= "nguyen", Email="nguyen@gmail.com", Password = "123456".HashPasswordMD5(), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now  },
                new Dealer{ UserName= "son", Email="son@gmail.com", Password = "123456".HashPasswordMD5(), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now  },
                new Dealer{ UserName= "duong", Email="duong@gmail.com", Password = "123456".HashPasswordMD5(), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now  },
            };
            foreach (ShowroomVehicle s in showroomvehicles)
            {
                context.ShowroomVehicles.Add(s);
            }
            context.SaveChanges();

            //Create dump orders
            var orders = new Order[]
            {
                new Order{ Address="".GenerateRandomId(10), OrderForm=false, StatusId=1, DealerId=random.Next(dealers.Count()), CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                new Order{ Address="".GenerateRandomId(10), OrderForm=true, StatusId=1, DealerId=random.Next(dealers.Count()), CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
                new Order{ Address="".GenerateRandomId(10), OrderForm=true, StatusId=1, DealerId=random.Next(dealers.Count()), CreatedAt=DateTime.Now, UpdatedAt=DateTime.Now},
            };
            foreach (OrderDetail o in OrderDetails)
            {
                context.OrderDetails.Add(o);
            }
            context.SaveChanges();

            //Create dump order details
            var orderdetails = new OrderDetail[]
            {
                new OrderDetail{ Quantity= 3, ShowroomVehicleId= 1 },
            };
            foreach (OrderDetail o in OrderDetails)
            {
                context.OrderDetails.Add(o);
            }
            context.SaveChanges();

            //Create dump status oder 
            var statusOders = new StatusOrder[]
            {
                new StatusOrder{ Name= "Deposit" },
                new StatusOrder{ Name= "Received" },
            };
            foreach (StatusOrder s in statusOders)
            {
                context.StatusOrders.Add(s);
            }
            context.SaveChanges();
        }


    }
}
