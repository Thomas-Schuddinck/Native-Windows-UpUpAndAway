using Shared.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Shared.DisplayModels
{
    public class DisplayOrder : INotifyPropertyChanged
    {
        #region Properties
        public int OrderId { get; set; }
        public ObservableCollection<DisplayOrderLine> OrderLines { get; set; } 
        public OrderStatus OrderStatus { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region ReadOnly-Properties
        public string TotalPrice => "Total: € " + OrderLines.Sum(o => o.Amount * o.Consumable.SellingPrice);
        #endregion

        #region Constructors
        public DisplayOrder()
        {
            OrderLines = new ObservableCollection<DisplayOrderLine>();
            OrderLines.CollectionChanged += ItemsChanged;
            OrderStatus = OrderStatus.Processing;
        }
        #endregion

        #region Methods
        private void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CleanUpOrderLines();
            NotifyPropertyChanged(nameof(TotalPrice));
        }

        public void ForceUpdate()
        {
            CleanUpOrderLines();
            NotifyPropertyChanged(nameof(TotalPrice));
        }

        public void CleanUpOrderLines()
        {
            List<DisplayOrderLine> LinesToRemove = OrderLines.Where(ol => ol.Amount <= 0).ToList();
            foreach (DisplayOrderLine orderLine in LinesToRemove)
            {
                OrderLines.Remove(orderLine);
            }
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
