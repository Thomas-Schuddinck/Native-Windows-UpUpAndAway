﻿using System;

namespace UpUpAndAwayApp.Models
{
    public class OrderLine
    {
        #region Properties
        public int OrderLineId { get; set; }
        public int Amount { get; set; }
        public Consumable Consumable { get; private set; }
        #endregion

        public OrderLine(int amount, Consumable consumable)
        {
            Amount = amount;
            Consumable = consumable;
        }
        
    }
}
