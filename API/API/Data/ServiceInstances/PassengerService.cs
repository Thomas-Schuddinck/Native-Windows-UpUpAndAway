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

        public PassengerService(Context context)
        {
            this.context = context;
            passengers = context.Passenger;
        }

        public ICollection<Passenger> GetAll()
        {
            return passengers.AsNoTracking().ToList();
        }

        public Passenger GetPassenger(int id)
        {
            return passengers.AsNoTracking().FirstOrDefault(s => s.PassengerId == id);
        }
    }
}
