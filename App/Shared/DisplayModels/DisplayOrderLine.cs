using Shared.DTOs;
using Shared.Models;
using System.ComponentModel;

namespace Shared.DisplayModels
{
    public class DisplayOrderLine : INotifyPropertyChanged
    {
        #region Fields
        private int _amount;
        private DisplayOrder _order; 
        #endregion

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

        #region ReadOnly-Properties
        public string AmountPrice => _amount + " X " + "€ " + Consumable.SellingPrice;
        public string TotalPrice => "€ " + (_amount * Consumable.SellingPrice);
        #endregion

        #region Constructors
        public DisplayOrderLine(int amount, Consumable consumable, DisplayOrder order)
        {
            _order = order;
            Amount = amount;
            Consumable = consumable;
        }

        public DisplayOrderLine(OrderLineDTO orderLineDTO, DisplayOrder order)
        {
            _order = order;
            Amount = orderLineDTO.Amount;
            Consumable = new Consumable(orderLineDTO.ConsumableDTO);
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
