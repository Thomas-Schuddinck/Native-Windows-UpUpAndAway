using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data.IServices
{
    public interface IConsumableService
    {
        /// <summary>
        /// Returns all Consumables.
        /// </summary>
        /// <returns>List of Consumables</returns>
        ICollection<Consumable> GetAll();


    }
}
