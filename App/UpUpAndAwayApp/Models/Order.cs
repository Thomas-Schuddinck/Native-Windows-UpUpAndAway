using API.Models.Enums;
using System;
using System.Collections.Generic;

namespace UpUpAndAwayApp.Models
{
    public class Order
    {
        #region Properties
        public int OrderId { get; set; }
        public List<OrderLine> OrderLines { get; private set; }
        public OrderStatus OrderStatus { get; private set; } 
        #endregion

        public Order(OrderStatus orderStatus)
        {
            OrderLines = new List<OrderLine>();
            OrderStatus = orderStatus;
        }
    }
}
