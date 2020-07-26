using System;

namespace API.Models
{
    public class Seat
    {
        #region Fields
        private int _seatNumber;
        #endregion

        #region Properties
        public int SeatNumber
        {
            get
            {
                return _seatNumber;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid seatnumber");
                _seatNumber = value;
            }
        }

        public Passenger Passenger { get; set; }
        #endregion

        #region Constructors
        public Seat()
        {

        }

        public Seat(int seatNumber, Passenger passenger)
        {
            SeatNumber = seatNumber;
            Passenger = passenger;
        }

        #endregion
    }
}
