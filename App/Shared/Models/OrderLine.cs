﻿using Shared.DTOs;
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
                return Amount;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Amount cannot be zero or less!");
                _amount = value;
            }
        }
        public Consumable Consumable { get; private set; }
        public int ConsumableId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
        #endregion

        public OrderLine(int amount, Consumable consumable, Order order)
        {
            Amount = amount;
            Consumable = consumable;
            ConsumableId = Consumable.ConsumableId;
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
            ConsumableId = Consumable.ConsumableId;
            OrderId = order.OrderId;
            Order = order;
        }

        public void SetNewAmount(int value)//#Wut Dubbele code, same als setter van amount
        {
            Amount = value;
        }
    }
}