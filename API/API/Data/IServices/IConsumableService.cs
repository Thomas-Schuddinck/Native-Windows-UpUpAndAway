using Shared.Models;
using System.Collections.Generic;

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
