using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using UpUpAndAwayApp.Models;
using UpUpAndAwayApp.Models.ListItemModels;

namespace UpUpAndAwayApp.ViewModels
{
    public class WebshopViewModel : INotifyPropertyChanged
    {

        #region Fields
        private WebshopItem _currentWebshopItem;
        #endregion

        #region Properties
        public ObservableCollection<WebshopItem> WebshopItems { get; private set; }

        public ObservableCollection<OrderLine> Cart { get; private set; }

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
        #endregion


        #region Constructors
        public WebshopViewModel()
        {
            WebshopItems = new ObservableCollection<WebshopItem>();
            //should previous cart => nog kijken voor local storage save
            Cart = new ObservableCollection<OrderLine>();
            GetConsumablesFromAPI();
        } 
        #endregion

        #region Methods
        private async void GetConsumablesFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Consumable"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Consumable>>(json);
            lst.ToList().ForEach(i => WebshopItems.Add(new WebshopItem(i, this)));
        }

        public void SendCurrentToShoppingCart()
        {
            AddToShoppingCart(CurrentWebshopItem);
        }

        public void RemoveItemFromCart(OrderLine orderLine)
        {
            Cart.Remove(orderLine);
        }

        public void ClearCart()
        {
            Cart = new ObservableCollection<OrderLine>();
        }

        public void AddToShoppingCart(WebshopItem webshopItem)
        {
            if (webshopItem.Amount > 0)
            {
                OrderLine o = Cart.FirstOrDefault(ol => ol.Consumable.ConsumableId == webshopItem.Consumable.ConsumableId);
                if (o == null)
                    Cart.Add(new OrderLine(webshopItem.Amount, webshopItem.Consumable));
                else
                    o.Amount += webshopItem.Amount;
                webshopItem.ResetAmount();
            }
        } 
        #endregion
    }
}
