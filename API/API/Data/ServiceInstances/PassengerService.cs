using API.Data.IServices;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Data.ServiceInstances
{
    public class PassengerService : IPassengerService
    {

        private readonly Context context;
        private readonly DbSet<Passenger> passengers;

        public PassengerService(Context context)
        {
            this.context = context;
            passengers = context.Passengers;
        }

        public ICollection<Passenger> GetAll()
        {
            return passengers.AsNoTracking().ToList();
        }

        public Passenger GetPassenger(int id)
        {
            return passengers.AsNoTracking().Where(s => s.PassengerId == id).FirstOrDefault();
        }
    }
}
