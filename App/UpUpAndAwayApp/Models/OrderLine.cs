using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UpUpAndAwayApp.Models
{
    public class OrderLine : INotifyPropertyChanged
    {
        private int _amount;
        private Order _order;

        #region Properties
        public int OrderLineId { get; set; }
        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged(nameof(Amount));
                NotifyPropertyChanged(nameof(AmountPrice));
                NotifyPropertyChanged(nameof(TotalPrice));
                _order.ForceUpdate();

            }
        }
        public Consumable Consumable { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public string AmountPrice => _amount + " X " + "€ " + Consumable.SellingPrice;
        public string TotalPrice => "€ " + (_amount * Consumable.SellingPrice);


        public OrderLine(int amount, Consumable consumable, Order order)
        {
            _order = order;
            Amount = amount;
            Consumable = consumable;
        }
        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
