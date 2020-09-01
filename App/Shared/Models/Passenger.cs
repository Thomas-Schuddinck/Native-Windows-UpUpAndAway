using Shared.DTOs;
using System;

namespace Shared.Models
{
    public class Passenger
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        #endregion

        #region Properties
        public int PassengerId { get; set; }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
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
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name of the passenger cannot be empty or containing only whitespace!");
                _lastName = value;
            }
        }
        #endregion

        #region ReadOnly-Properties
        public string FullName => FirstName + " " + LastName;
        #endregion

        #region Constructors
        public Passenger() { }

        public Passenger(PassengerDTO passengerDTO)
        {
            if (passengerDTO.Exists)
            {
                PassengerId = passengerDTO.PassengerId;
                FirstName = passengerDTO.FirstName;
                LastName = passengerDTO.LastName;
            }
            else
            {
                PassengerId = -1;
            }

        }

        public Passenger(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        } 
        #endregion


    }
}
