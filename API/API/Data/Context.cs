using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Consumable>();
            mb.Entity<OrderLine>().HasOne(s => s.Consumable).WithMany();
            mb.Entity<Order>().OwnsMany(s => s.OrderLines);
            mb.Entity<Passenger>().HasMany(s => s.PlacedOrders).WithOne();
            mb.Entity<PassengerParty>().HasMany(s => s.Passengers);

            //TODO Test
        }
    }
}
