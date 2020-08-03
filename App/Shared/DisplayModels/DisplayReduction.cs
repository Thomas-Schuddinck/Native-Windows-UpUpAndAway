using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace Shared.DisplayModels
{
    public class DisplayReduction : INotifyPropertyChanged
    {
        #region Properties
        
        public ObservableCollection<DisplayOrderLine> OrderLines { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Constructors
        public DisplayReduction()
        {
            OrderLines = new ObservableCollection<DisplayOrderLine>();
            //OrderLines.CollectionChanged += ItemsChanged;
        }
        #endregion

        #region Methods
        //private void ItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    CleanUpOrderLines();
        //    NotifyPropertyChanged(nameof(TotalPrice));
        //}

        //public void ForceUpdate()
        //{
        //    CleanUpOrderLines();
        //    NotifyPropertyChanged(nameof(TotalPrice));
        //}

        //public void CleanUpOrderLines()
        //{
        //    List<DisplayOrderLine> LinesToRemove = OrderLines.Where(ol => ol.Amount <= 0).ToList();
        //    foreach (DisplayOrderLine orderLine in LinesToRemove)
        //    {
        //        OrderLines.Remove(orderLine);
        //    }
        //}

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
