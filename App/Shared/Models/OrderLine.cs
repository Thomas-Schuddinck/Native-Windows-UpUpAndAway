using Shared.DTOs;
using System;

namespace Shared.Models
{
    public class OrderLine
    {
        #region Fields
        private int _amount;
        #endregion

        #region Properties
        public int OrderLineId { get; set; }
        public int Amount
        {
            get
            {
                return _amount;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Amount cannot be zero or less!");
                _amount = value;
            }
        }
        public Consumable Consumable { get; set; }
        public int ConsumableId => Consumable.ConsumableId;

        public Order Order { get; set; }
        public int OrderId { get; set; }
        #endregion

        public OrderLine(int amount, Consumable consumable, Order order)
        {
            Amount = amount;
            Consumable = consumable;
            Order = order;
            OrderId = order.OrderId;
        }

        public OrderLine()
        {

        }

        public OrderLine(OrderLineDTO orderLineDTO, Order order)
        {
            Amount = orderLineDTO.Amount;
            Consumable = new Consumable(orderLineDTO.ConsumableDTO);
            OrderId = order.OrderId;
            Order = order;
        }

        public void SetNewAmount(int value)//#Wut Dubbele code, same als setter van amount
        {
            Amount = value;
        }
    }
}
