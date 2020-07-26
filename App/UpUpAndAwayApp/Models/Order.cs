using API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UpUpAndAwayApp.Models
{
    public class Order : INotifyPropertyChanged
    {

        #region Properties
        public int OrderId { get; set; }
        public ObservableCollection<OrderLine> OrderLines { get; set; } 
        public OrderStatus OrderStatus { get; private set; }
        public string TotalPrice => "Total: € " + OrderLines.Sum(o => o.Amount * o.Consumable.SellingPrice);
        #endregion

        public Order()
        {
            OrderLines = new ObservableCollection<OrderLine>();
            OrderLines.CollectionChanged += ItemsChanged;
            OrderStatus = OrderStatus.Cart;
        }

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


        public event PropertyChangedEventHandler PropertyChanged;

        public void CleanUpOrderLines()
        {
            List<OrderLine> LinesToRemove = OrderLines.Where(ol => ol.Amount <= 0).ToList();
            foreach(OrderLine orderLine in LinesToRemove)
            {
                OrderLines.Remove(orderLine);
            }
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
