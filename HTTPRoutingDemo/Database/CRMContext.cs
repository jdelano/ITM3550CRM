using System;
using Microsoft.EntityFrameworkCore;
using HTTPRoutingDemo.Database.Models;

namespace HTTPRoutingDemo.Database
{
    public class CRMContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public CRMContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("CRM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "Jim", LastName = "Jones", Balance = 200.0 },
                new Customer { CustomerId = 2, FirstName = "Alfred", LastName = "Akens", Balance = 1200.0 });

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = DateTime.Now, NumberOfItemsInOrder = 2, OrderTotal = 203.43 },
                new Order { OrderId = 2, OrderDate = DateTime.Now - TimeSpan.FromDays(90), NumberOfItemsInOrder = 2, OrderTotal = 203.43 });
        }
    }
}
