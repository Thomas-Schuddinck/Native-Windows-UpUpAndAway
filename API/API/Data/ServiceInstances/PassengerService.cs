using API.Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Data.ServiceInstances
{
    public class PassengerService : IPassengerService
    {

        private readonly Context context;
        private readonly DbSet<Passenger> passengers;
        private readonly DbSet<Seat> seats;
        private readonly DbSet<PassengerParty> parties;

        public PassengerService(Context context)
        {
            this.context = context;
            passengers = context.Passengers;
            seats = context.Seats;
            parties = context.PassengerParties;
        }

        public ICollection<Passenger> GetAll()
        {
            return passengers.AsNoTracking().ToList();
        }

        public Passenger GetPassenger(int id)
        {
            return passengers.AsNoTracking().FirstOrDefault(s => s.PassengerId == id);
        }

        public Seat GetPassengerBySeatnumber(int seatnumber)
        {
            return seats.AsNoTracking().Include(s => s.Passenger).Where(s => s.SeatId == seatnumber).FirstOrDefault();
        }

        public PassengerParty GetParty(int id)
        {
            Passenger p = GetPassenger(id);
            return parties.AsNoTracking().Where(s => s.Passengers.Contains(p)).FirstOrDefault();
        }

        public ICollection<Passenger> GetPartyMembers(int partyId, int passengerId)
        {
            return parties.AsNoTracking().Include(p => p.Passengers).FirstOrDefault(p => p.PassengerPartyId == partyId).Passengers.Where(p => p.PassengerId != passengerId).ToList();
        }

        public PassengerParty GetPartyOfPassenger(int passId)
        {
            return parties.Include(s => s.Passengers)
                .AsNoTracking().SingleOrDefault(s => s.Passengers
                    .Any(t => t.PassengerId == passId));
        }
    }
}
