using Shared.DTOs;
using System;

namespace Shared.Models
{
    public class Seat
    {
        #region Fields
        private int _seatNumber;
        #endregion

        #region Properties
        public int SeatId
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
        public Seat(SeatDTO seatdto)
        {
            this.SeatId = seatdto.SeatId;
            this.Passenger = null;
        }

        public Seat(int seatNumber)
        {
            SeatId = seatNumber;
            Passenger = null;
        }

        public Seat(int seatNumber, Passenger passenger)
        {
            SeatId = seatNumber;
            Passenger = passenger;
        }

        #endregion
    }
}
