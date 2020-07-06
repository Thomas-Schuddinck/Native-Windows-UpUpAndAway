using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Order
    {
        #region Properties
        /// <summary>
        /// ID of this Order.
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// List of Consumables and how much of these were ordered.
        /// </summary>
        public List<OrderLine> OrderLines { get; private set; }
        /// <summary>
        /// Status of this Order. Use to filter Orders.
        /// </summary>
        public OrderStatus OrderStatus { get; private set; }

        /// <summary>
        /// Passenger that placed this Order.
        /// </summary>
        public Passenger Passenger { get; set; }
        /// <summary>
        /// ID of the Passenger. Needed to properly link Passenger and Order.
        /// </summary>
        public int PassengerId { get; set; }
        #endregion

        /// <summary>
        /// For EF
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Normal constructor. Makes a new Order.
        /// </summary>
        /// <param name="orderLines">Items in the Order</param>
        /// <param name="passenger">User that placed the Order</param>
        public Order(List<OrderLine> orderLines, Passenger passenger)
        {
            OrderLines = orderLines;
            OrderStatus = OrderStatus.Processing;
            Passenger = passenger;
            PassengerId = Passenger.PassengerId;
        }

        public bool Finish()
        {
            if (OrderStatus == OrderStatus.Finished)
                return false;
            OrderStatus = OrderStatus.Finished;
            return true;
        }
    }

    public enum OrderStatus
    {
        /// <summary>
        /// Not yet finished
        /// </summary>
        Processing,
        /// <summary>
        /// Finished Order
        /// </summary>
        Finished
    }

}
