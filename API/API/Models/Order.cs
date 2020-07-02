using System;
using System.Collections.Generic;

namespace API.Models
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

        public void SetAmountForOrderLine(OrderLine orderLine, int amount)
        {
            try
            {
                orderLine.SetNewAmount(amount);//#Wut throwt niet eens een exception
            }
            catch (ArgumentException ex)
            {
                OrderLines.Remove(orderLine);
            }
        }

        public void UpdateStatus(OrderStatus orderStatus)
        {
            OrderStatus++;
            if (!(Enum.IsDefined(typeof(OrderStatus), OrderStatus)))
            {
                OrderStatus--;
                throw new IndexOutOfRangeException();
            }
        }
    }
}
