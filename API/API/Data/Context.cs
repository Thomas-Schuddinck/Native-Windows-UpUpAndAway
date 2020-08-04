﻿using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Data
{
    public class Context : DbContext
    {
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PassengerParty> PassengerParties { get; set; }
        public DbSet<Song> Songs { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Consumable>();
            mb.Entity<Song>();
            mb.Entity<Order>().HasMany(s => s.OrderLines).WithOne(o => o.Order);
            mb.Entity<Order>().HasOne(s => s.Passenger).WithMany();
            mb.Entity<OrderLine>().HasOne(s => s.Consumable).WithMany();
            mb.Entity<Passenger>();//.HasMany(s => s.PlacedOrders).WithOne();
            mb.Entity<PassengerParty>().HasMany(s => s.Passengers).WithOne();

            //TODO Test
        }


    }
}
