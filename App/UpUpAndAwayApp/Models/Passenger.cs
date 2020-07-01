using System;

namespace API.Models
{
    public class Passenger
    {

        #region Fields
        private string _firstName;
        private string _lastName;
        private int _seatNumber;
        #endregion

        #region Properties
        public int PassengerId { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name of the passenger cannot be empty or containing only whitespace!");
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name of the passenger cannot be empty or containing only whitespace!");
                _lastName = value;
            }
        }
        public int SeatNumber
        {
            get
            {
                return _seatNumber;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Seat number cannot be negative!");
                _seatNumber = value;
            }
        }
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
