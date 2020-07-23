using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models;
using UpUpAndAwayApp.Models.ListItemModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UpUpAndAwayApp.ViewModels
{
    public class WebshopViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WebshopItem> WebshopItems { get; private set; }

        public ObservableCollection<OrderLine> Cart { get; private set; }

        private WebshopItem _currentWebshopItem;

        public WebshopItem CurrentWebshopItem
        {
            get { return this._currentWebshopItem; }
            set
            {
                if (_currentWebshopItem == value)
                    return;
                _currentWebshopItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentWebshopItem"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public WebshopViewModel()
        {
            WebshopItems = new ObservableCollection<WebshopItem>();
            Cart = new ObservableCollection<OrderLine>();
            GetConsumablesFromAPI();
        }

        private async void GetConsumablesFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Consumable"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(json);
            lst.ToList().ForEach(i => WebshopItems.Add(new WebshopItem(i, this)));
        }


        public void AddToShoppingCart(WebshopItem webshopItem)
        {
            OrderLine o = Cart.FirstOrDefault(ol => ol.Consumable.ConsumableId == webshopItem.Consumable.ConsumableId);
            if (o == null)
                Cart.Add(new OrderLine(webshopItem.Amount, webshopItem.Consumable));
            else
                o.Amount += webshopItem.Amount;
            webshopItem.ResetAmount();
        }
    }
}
