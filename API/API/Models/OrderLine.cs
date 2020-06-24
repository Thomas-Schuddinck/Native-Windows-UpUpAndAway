using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderLine
    {
        #region Fields
        private int _amount;
        #endregion

        #region Properties
        public int OrderLineId { get; private set; }
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
        #endregion

        public OrderLine(int orderLineId, int amount, Consumable consumable)
        {
            OrderLineId = orderLineId;
            Amount = amount;
            Consumable = consumable;
        }

        public void SetNewAmount(int value)
        {
            Amount =value;
        }
    }
}
