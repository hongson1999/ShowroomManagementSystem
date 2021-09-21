using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Context
{
    public class ShowroomDbContext : DbContext
    {
        public ShowroomDbContext( DbContextOptions options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ShowroomVehicle> ShowroomVehicles { get; set; }
        public DbSet<WarehouseVehicle> WarehouseVehicles { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().ToTable("Branchs");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<ShowroomVehicle>().ToTable("ShowroomVehicles");
            modelBuilder.Entity<WarehouseVehicle>()
                .ToTable("WarehouseVehicles")
                .HasOne(wv => wv.Vehicle)
                .WithMany(v => v.WarehouseVehicles)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Dealer>().ToTable("Dealers");
            modelBuilder.Entity<StatusOrder>().ToTable("StatusOrders");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        }

        public DbSet<Server.Models.Service> Service { get; set; }

        public DbSet<Server.Models.Dealer> Dealer { get; set; }
    }
}
