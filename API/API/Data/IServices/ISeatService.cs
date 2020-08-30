using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.IServices
{
    public interface ISeatService
    {
        /// <summary>
        /// Returns List of all Seats
        /// </summary>
        /// <returns>List of Seats</returns>
        ICollection<Seat> GetAll();
        Seat GetByPassenger(int passengerid);

        /// <summary>
        /// Swaps the Passengers on both seats. Seat1 must always have a Passenger, Seat2 can be empty.
        /// </summary>
        /// <param name="seat1">Seat Passenger is originally sitting on</param>
        /// <param name="seat2">Seat Passenger will be swapping to.</param>
        /// <returns>True if successful</returns>
        bool SwapSeats(int seat1, int seat2);

    }
}
