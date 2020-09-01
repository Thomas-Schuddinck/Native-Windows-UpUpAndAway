using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System.Collections.Generic;

namespace API.Data.IServices
{
    public interface IPassengerService
    {
        Passenger GetPassenger(int id);
        PassengerParty GetParty(int id);
        Seat GetPassengerBySeatnumber(int seatnumber);
        ICollection<Passenger> GetAll();
        ICollection<Passenger> GetPartyMembers(int partyId, int passengerId);
        PassengerParty GetPartyOfPassenger(int passId);
    }
}
