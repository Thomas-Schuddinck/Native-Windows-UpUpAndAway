using Shared.DTOs;
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

        /// <summary>
        /// Updates the reductions for all consumables.
        /// </summary>
        /// <param name="items">New reductions coupled to the ID</param>
        /// <returns>True if successful</returns>
        bool UpdateReductions(ICollection<ReductionChangeItemDTO> items);

    }
}
