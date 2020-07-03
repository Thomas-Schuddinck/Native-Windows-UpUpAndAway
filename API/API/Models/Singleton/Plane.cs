using System;
using System.Collections.Generic;

namespace API.Models.Singleton
{
    public class Plane
    {
        private int _totalNumberOfSeats;
        private static readonly Plane instance = new Plane();
        public FlightInfoSingleton FlightInfo = FlightInfoSingleton.GetInstance();
        public Dictionary<int, Passenger> Seats = new Dictionary<int, Passenger>();
        

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

        private Plane()
        {
            TotalNumberOfSeats = 50; //Dit is gewoon een constante (voorbeeld)-waarde
        }

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
                Passenger tempPassenger = FillSeat(i, remainingPassengerList);
                remainingPassengerList.Remove(tempPassenger);
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
            foreach(Passenger passenger in passengers){
                if(passenger.SeatNumber == seatnumber)
                {
                    SetupPassengerWithSeat(seatnumber, passenger);
                    return passenger;
                }
            }
            SetupPassengerWithSeat(seatnumber);
            return null;
        }

        /// <summary>
        /// Add a passenger to a certain seat
        /// </summary>
        /// <param name="seatnumber">the number of the seat</param>
        /// <param name="passenger">the passenger</param>
        public void SetupPassengerWithSeat(int seatnumber, Passenger passenger = null)
        {
            CheckValidSeat(seatnumber);
            Seats[seatnumber] = passenger;
            if (passenger != null)
                passenger.SeatNumber = seatnumber;
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
            Passenger passengerTemp = Seats[seatnumber2];
            SetupPassengerWithSeat(seatnumber2, Seats[seatnumber1]);
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
        #endregion
    }
}

