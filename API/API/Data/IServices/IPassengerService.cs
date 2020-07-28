using Shared.Models;
using System.Collections.Generic;

namespace API.Data.IServices
{
    public interface IPassengerService
    {
        Passenger GetPassenger(int id);
        PassengerParty GetParty(int id);
        ICollection<Passenger> GetAll();
    }
}
