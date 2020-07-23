using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UpUpAndAwayApp.Models
{
    public class OrderLine : INotifyPropertyChanged
    {
        private int _amount;


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
                if (value < 0)
                    return;
                _amount = value;
                OnPropertyChanged();

            }
        }
        public Consumable Consumable { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public string AmountPrice => Amount + " X " + "€ " + Consumable.SellingPrice;
        public string TotalPrice => "€ " + (Amount * Consumable.SellingPrice);


        public OrderLine(int amount, Consumable consumable)
        {
            Amount = amount;
            Consumable = consumable;
        }

        protected void OnPropertyChanged([CallerMemberName] string amount = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(amount));
        }
    }
}
