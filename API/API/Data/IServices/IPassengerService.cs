using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.IServices
{
    public interface IPassengerService
    {
        Passenger GetPassenger(int id);
        ICollection<Passenger> GetAll();
    }
}
