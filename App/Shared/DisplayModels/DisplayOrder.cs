using Shared.DTOs;
using Shared.Enums;
using Shared.Models;
using System;
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
        public Passenger Passenger { get; set; }
        public ObservableCollection<DisplayOrderLine> OrderLines { get; set; } 
        public OrderStatus OrderStatus { get; private set; }
        public DateTime DateTimePlaced { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region ReadOnly-Properties
        public string TotalPrice => "Total: € " + OrderLines.Sum(o => o.Amount * o.Consumable.SellingPrice);
        public string NumberOfItems => OrderLines.Sum(o => o.Amount) + " items";
        public string DateTimePlacedConverter => String.Format("{0}/{1} {2}:{3}", DateTimePlaced.Day.ToString("00"), DateTimePlaced.Month.ToString("00"), DateTimePlaced.Hour.ToString("00"), DateTimePlaced.Minute.ToString("00"));
        #endregion

        #region Constructors
        public DisplayOrder()
        {
            OrderLines = new ObservableCollection<DisplayOrderLine>();
            OrderLines.CollectionChanged += ItemsChanged;
            OrderStatus = OrderStatus.Processing;
        }

        public DisplayOrder(OrderDTO orderDTO)
        {
            OrderId = orderDTO.OrderID;
            OrderLines = new ObservableCollection<DisplayOrderLine>();
            orderDTO.OrderLines.ForEach(ol => OrderLines.Add(new DisplayOrderLine(ol, this)));
            OrderLines.CollectionChanged += ItemsChanged;
            OrderStatus = orderDTO.OrderStatus;
            Passenger = new Passenger(orderDTO.Passenger);
            DateTimePlaced = orderDTO.DateTimePlaced;
        }
        #endregion

        #region Methods
        private void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CleanUpOrderLines();
            NotifyPropertyChanged(nameof(TotalPrice));
            NotifyPropertyChanged(nameof(NumberOfItems));
            NotifyPropertyChanged(nameof(DateTimePlacedConverter));
        }

        public void ForceUpdate()
        {
            CleanUpOrderLines();
            NotifyPropertyChanged(nameof(TotalPrice));
            NotifyPropertyChanged(nameof(NumberOfItems));
            NotifyPropertyChanged(nameof(DateTimePlacedConverter));
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
