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

    }
}
