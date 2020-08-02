using System.Collections.Generic;

namespace Shared.Models
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
