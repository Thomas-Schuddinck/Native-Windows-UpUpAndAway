using Microsoft.EntityFrameworkCore;
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

        public DbSet<Game> Games { get; set; }
        public DbSet<Guess> Guesses { get; set; }
        public DbSet<GamePair> GamePairs { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {


            mb.Entity<Consumable>();
            mb.Entity<Order>().HasMany(s => s.OrderLines).WithOne(o => o.Order);
            mb.Entity<Order>().HasOne(s => s.Passenger).WithMany();
            mb.Entity<OrderLine>().HasOne(s => s.Consumable).WithMany();
            mb.Entity<Passenger>();//.HasMany(s => s.PlacedOrders).WithOne();
            mb.Entity<PassengerParty>().HasMany(s => s.Passengers).WithOne();

            mb.Entity<GamePair>().HasOne(gp => gp.FirstGame).WithOne().HasForeignKey<GamePair>(g => g.FirstGameId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<GamePair>().HasOne(gp => gp.SecondGame).WithOne().HasForeignKey<GamePair>(g => g.SecondGameId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<HangmanGame>().HasOne(g => g.Player).WithMany();
            mb.Entity<WordGuess>();
            mb.Entity<CharGuess>();



            //TODO Test
        }


    }
}
