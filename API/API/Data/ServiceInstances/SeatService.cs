using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.ServiceInstances
{
    public class SeatService : ISeatService
    {

        private readonly Context context;
        private readonly DbSet<Seat> seats;

        public SeatService(Context ct)
        {
            context = ct;
            seats = context.Seats;
        }
        public ICollection<Seat> GetAll()
        {
            return seats.Include(s => s.Passenger).AsNoTracking().ToList();
        }

        public Seat GetByPassenger(int passengerid)
        {
            return seats.Include(s => s.Passenger).AsNoTracking().Where(s => s.Passenger.PassengerId == passengerid).FirstOrDefault();
        }

        public bool SwapSeats(int seat1, int seat2)
        {
            //Get seats from DB and check for null
            var s1 = seats.Include(s => s.Passenger).SingleOrDefault(s => s.SeatId == seat1);
            var s2 = seats.Include(s => s.Passenger).SingleOrDefault(s => s.SeatId == seat2);
            if (s1 == null || s2 == null)
                return false;

            var temp = s1.Passenger;//Swap seats
            s1.Passenger = s2.Passenger;
            s2.Passenger = temp;

            seats.UpdateRange(new[] { s1, s2 });//Update
            return context.SaveChanges() == 2;//If everything went fine, there should be 2 updates entries
        }
    }
}
