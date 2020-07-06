using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Data.IServices
{
    public interface IOrderInterface
    {
        /// <summary>
        /// Places a new Order.
        /// </summary>
        /// <param name="order">Order to place.</param>
        /// <returns>ID of the Order</returns>
        int PlaceOrder(Order order);

        /// <summary>
        /// Sets an Order as finished.
        /// </summary>
        /// <param name="id">ID of the Order</param>
        /// <returns>True if successful</returns>
        bool FinishOrder(int id);

        /// <summary>
        /// Returns all the Orders of a single Passanger
        /// </summary>
        /// <param name="passengerId">ID of the Passenger</param>
        /// <returns>List of Orders for the given Passenger. Empty List of none found.</returns>
        ICollection<Order> GetByUser(int passengerId);

        /// <summary>
        /// Returns all Orders
        /// </summary>
        /// <returns>List of all Orders</returns>
        ICollection<Order> GetAll();
    }
}
