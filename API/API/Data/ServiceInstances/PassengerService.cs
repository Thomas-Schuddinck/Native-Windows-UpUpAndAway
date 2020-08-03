using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<PassengerParty> parties;

        public PassengerService(Context context)
        {
            this.context = context;
            passengers = context.Passengers;
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

        public PassengerParty GetParty(int id)
        {
            Passenger p = GetPassenger(id);
            return parties.AsNoTracking().Where(s => s.Passengers.Contains(p)).FirstOrDefault();
        }
    }
}
