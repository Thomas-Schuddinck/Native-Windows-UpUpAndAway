﻿using System;

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
        public int PassengerId { get; private set; }
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

        public Passenger(int passengerId, string firstName, string lastName, int seatNumber)
        {
            PassengerId = passengerId;
            FirstName = firstName;
            LastName = lastName;
            SeatNumber = seatNumber;
        }

        /// <summary>
        /// Swap the seat numbers of this passenger and a given other passenger
        /// </summary>
        /// <param name="otherPassenger">the other passenger whose seat number will be swapped with this passenger</param>
        public void SwapSeats(Passenger otherPassenger)
        {
            SeatNumber += otherPassenger.SeatNumber;
            otherPassenger.SeatNumber = SeatNumber - otherPassenger.SeatNumber;
            SeatNumber -= otherPassenger.SeatNumber;
        }
    }
}