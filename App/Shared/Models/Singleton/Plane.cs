using System;
using System.Linq;
using System.Collections.Generic;

namespace Shared.Models.Singleton
{
    public class Plane
    {
        #region Fields
        private int _totalNumberOfSeats; 
        #endregion

        private static readonly Plane instance = new Plane();
        public FlightInfoSingleton FlightInfo = FlightInfoSingleton.GetInstance();
        public List<Seat> Seats;        

        public int TotalNumberOfSeats
        {
            get
            {
                return _totalNumberOfSeats;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Total number of seats cannot be negative");
                _totalNumberOfSeats = value;
            }
        }

        #region Constructors
        private Plane()
        {
            TotalNumberOfSeats = 50; //Dit is gewoon een constante (voorbeeld)-waarde
            Seats = new List<Seat>();
        } 
        #endregion

        #region Methods
        public static Plane GetInstance() => instance;

        /// <summary>
        /// Assign all passengers to their designated seat and fill empty seats with null
        /// </summary>
        /// <param name="passengers">the list of passengers</param>
        public void SetupPlane(List<Passenger> passengers)
        {
            List<Passenger> remainingPassengerList = passengers;
            for(int i = 0; i < TotalNumberOfSeats; i++)
            {
                remainingPassengerList.Remove(FillSeat(i, remainingPassengerList));
            }
        }

        /// <summary>
        /// Fill seat with designated passenger, fill with null if no such passenger exists
        /// </summary>
        /// <param name="seatnumber">the number of the seat to be filled</param>
        /// <param name="passengers">list of all passengers</param>
        /// <returns>returns passenger if one's designated, else null</returns>
        public Passenger FillSeat(int seatnumber, List<Passenger> passengers)
        {
            Passenger passenger = FindPassengerBySeatNumber(seatnumber);                
            SetupPassengerWithSeat(seatnumber, passenger);
            return passenger;
        }

        /// <summary>
        /// Add a passenger to a certain seat
        /// </summary>
        /// <param name="seatnumber">the number of the seat</param>
        /// <param name="passenger">the passenger</param>
        public void SetupPassengerWithSeat(int seatnumber, Passenger passenger = null)
        {
            CheckValidSeat(seatnumber);
            Seats.Add(new Seat(seatnumber, passenger));            
        }

        /// <summary>
        /// Swap 2 seats wheter or not there are zero, one or two passengers seated on those seats
        /// </summary>
        /// <param name="seatnumber1">the first seat</param>
        /// <param name="seatnumber2">the second seat</param>
        public void SwapSeats(int seatnumber1, int seatnumber2)
        {
            CheckValidSeat(seatnumber1);
            CheckValidSeat(seatnumber2);
            if (seatnumber1 == seatnumber2) //if seats are the same than there's no need to swap
                return;
            Passenger passengerTemp = FindPassengerBySeatNumber(seatnumber2);
            SetupPassengerWithSeat(seatnumber2, FindPassengerBySeatNumber(seatnumber1));
            SetupPassengerWithSeat(seatnumber1, passengerTemp);
        } 

        /// <summary>
        /// Check if the given seatnumber is valid
        /// </summary>
        /// <param name="seatnumber">the seatnumber to be checked</param>
        public void CheckValidSeat(int seatnumber)
        {
            if (seatnumber > TotalNumberOfSeats)
                throw new ArgumentException("Invalid seatnumber");
        }

        public Passenger FindPassengerBySeatNumber(int seatnumber)
        {
            return Seats.FirstOrDefault(s => s.SeatId == seatnumber)?.Passenger;
        }
        #endregion
    }
}

