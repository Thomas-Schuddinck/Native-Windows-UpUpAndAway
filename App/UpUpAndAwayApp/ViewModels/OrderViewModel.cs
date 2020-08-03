using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DisplayModels.Singleton;
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
    public class OrderViewModel : INotifyPropertyChanged
    {
        private DisplayOrder _currentOpenOrder;
        private DisplayOrder _currentClosedOrder;
        private ObservableCollection<DisplayOrder> _openOrders;
        private ObservableCollection<DisplayOrder> _closedOrders;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<DisplayOrder> OpenOrders
        {
            get
            {
                return _openOrders;
            }
            private set
            {
                _openOrders = value;
                RaisePropertyChanged(nameof(OpenOrders));
            }
        }
        public ObservableCollection<DisplayOrder> ClosedOrders
        {
            get
            {
                return _closedOrders;
            }
            private set
            {
                _closedOrders = value;
                RaisePropertyChanged(nameof(ClosedOrders));
            }
        }
        public DisplayOrder CurrentOpenOrder
        {
            get { return this._currentOpenOrder; }
            set
            {
                if (_currentOpenOrder == value)
                    return;
                _currentOpenOrder = value;
                RaisePropertyChanged(nameof(CurrentOpenOrder));
            }
        }
        public DisplayOrder CurrentClosedOrder
        {
            get { return this._currentClosedOrder; }
            set
            {
                if (_currentClosedOrder == value)
                    return;
                _currentClosedOrder = value;
                RaisePropertyChanged(nameof(CurrentClosedOrder));
            }
        }

        public OrderViewModel()
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
            String uri = LoginSingleton.passenger == null ? "http://localhost:5000/api/Order" : String.Format("http://localhost:5000/api/Order/{0}", LoginSingleton.passenger.PassengerId);
            var json = await client.GetStringAsync(new Uri(uri));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<OrderDTO>>(json);
            lst.ToList().ForEach(i => AddOrder(i));
        }

        public async void CloseOrder(int id)
        {
            HttpClient client = new HttpClient();
            var s = await client.PutAsync("http://localhost:5000/api/Order", new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json"));
            RefreshOrders();
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
