using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Shared.DisplayModels
{
    public class DisplayReductionLine : INotifyPropertyChanged
    {
        #region Fields
        private double _amount;
        private DisplayReduction red;
        #endregion

        #region Properties
        public int OrderLineId { get; set; }
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged(nameof(TotalPrice));
                //red.ForceUpdate();

            }
        }
        public Consumable Consumable { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region ReadOnly-Properties

        public string TotalPrice => "€ " + (_amount * Consumable.SellingPrice);
        #endregion

        #region Constructors
        public DisplayReductionLine(double amount, Consumable consumable, DisplayReduction red)
        {
            this.red = red;
            Amount = amount;
            Consumable = consumable;
        }
        #endregion

        #region Methods
        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
