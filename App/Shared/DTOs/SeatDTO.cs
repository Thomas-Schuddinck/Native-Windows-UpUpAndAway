using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class SeatDTO
    {
        public int SeatId { get; set; }
        public int PassengerId { get; set; }

        public SeatDTO() { }
        public SeatDTO(Seat seat) {
            this.SeatId = seat.SeatId;
            this.PassengerId = seat.Passenger.PassengerId;
        }
    }
}
