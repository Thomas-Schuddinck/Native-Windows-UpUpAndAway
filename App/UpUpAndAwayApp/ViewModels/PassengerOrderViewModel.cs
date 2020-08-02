using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DTOs;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class PassengerOrderViewModel
    {

        public ObservableCollection<DisplayOrder> OpenOrders { get; private set; }
        public ObservableCollection<DisplayOrder> ClosedOrders { get; private set; }

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
    }
}
