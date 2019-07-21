using Microsoft.EntityFrameworkCore;
using OrderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp.Core.DatabaseContext
{
    public class OrderAppContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.56;Database=postgres;Username=postgres;Password=P@ssw0rd");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
