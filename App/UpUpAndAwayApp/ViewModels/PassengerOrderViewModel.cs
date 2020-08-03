using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DTOs;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class PassengerOrderViewModel : INotifyPropertyChanged
    {
        private DisplayOrder _currentOrder;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<DisplayOrder> OpenOrders { get; private set; }
        public ObservableCollection<DisplayOrder> ClosedOrders { get; private set; }
        public DisplayOrder CurrentOrder
        {
            get { return this._currentOrder; }
            set
            {
                if (_currentOrder == value)
                    return;
                _currentOrder = value;
                RaisePropertyChanged(nameof(CurrentOrder));
            }
        }

        public PassengerOrderViewModel()
        {
            RefreshOrders();
        }

        private void RefreshOrders()
        {
            OpenOrders = new ObservableCollection<DisplayOrder>();
            ClosedOrders = new ObservableCollection<DisplayOrder>();
            GetOrdersFromAPI();
        }

        private async void GetOrdersFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Order"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<OrderDTO>>(json);
            lst.ToList().ForEach(i => AddOrder(i));
        }

        private void AddOrder(OrderDTO order)
        {
            if (order.OrderStatus == OrderStatus.Processing)
                OpenOrders.Add(new DisplayOrder(order));
            else
                ClosedOrders.Add(new DisplayOrder(order));
        }

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
