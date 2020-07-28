using API.Data.IServices;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            passengers = context.Passenger;
            parties = context.PassengerParties;
        }

        public ICollection<Passenger> GetAll()
        {
            return passengers.AsNoTracking().ToList();
        }

        public Passenger GetPassenger(int id)
        {
            return passengers.AsNoTracking().Where(s => s.PassengerId == id).FirstOrDefault();
        }

        public PassengerParty GetParty(int id)
        {
            Passenger p = GetPassenger(id);
            return parties.AsNoTracking().Where(s => s.Passengers.Contains(p)).FirstOrDefault();
        }
    }
}
