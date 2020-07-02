using System;

namespace API.Models
{
    public class Passenger
    {
        #region Properties
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
        public int SeatNumber { get; set; }
        public string FullName => FirstName + " " + LastName; 
        #endregion

        public Passenger(string firstName, string lastName, int seatNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SeatNumber = seatNumber;
        }
        
    }
}
