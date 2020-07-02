using System.Collections.Generic;

namespace API.Models
{
    public class PassengerParty
    {
        #region Properties
        public int PassengerPartyId { get; set; }
        public List<Passenger> Passengers { get; set; } 
        #endregion

        public PassengerParty()
        {
            Passengers = new List<Passenger>();
        }
    }
}
