using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class WebshopViewModel
    {
        public ObservableCollection<WebshopItem> WebshopItems { get; private set; }

        public ObservableCollection<OrderLine> Cart { get; private set; }

        public WebshopViewModel()
        {
            WebshopItems = new ObservableCollection<WebshopItem>();
            Cart = new ObservableCollection<OrderLine>();
            GetConsumablesFromAPI();
        }

        private async void GetConsumablesFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:50962/api/Consumable"));
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
