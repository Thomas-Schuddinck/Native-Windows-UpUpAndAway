﻿using Shared.Models;

namespace Shared.DTOs
{
    public class PassengerDTO
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PartyID { get; set; }
        public bool Exists { get; set; }

        public PassengerDTO()
        {
        }

        public PassengerDTO(Passenger passenger = null)
        {
            Exists = passenger != null;
            if (passenger != null)
            {
                PassengerId = passenger.PassengerId;
                FirstName = passenger.FirstName;
                LastName = passenger.LastName;
            }
        }
    }
}
