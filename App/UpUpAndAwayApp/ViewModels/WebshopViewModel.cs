using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using UpUpAndAwayApp.Models;
using UpUpAndAwayApp.Models.ListItemModels;
using UpUpAndAwayApp.Models.Singleton;

namespace UpUpAndAwayApp.ViewModels
{
    public class WebshopViewModel : INotifyPropertyChanged
    {

        #region Fields
        private WebshopItem _currentWebshopItem;
        private Order _cart;
        #endregion

        #region Properties
        public ObservableCollection<WebshopItem> WebshopItems { get; private set; }

        public Order Cart
        {
            get { return this._cart; }
            set
            {
                LoginSingleton.Cart = value;
                _cart = value;
                _cart.CleanUpOrderLines();
                RaisePropertyChanged(nameof(Cart));
            }
        }

        public WebshopItem CurrentWebshopItem
        {
            get { return this._currentWebshopItem; }
            set
            {
                if (_currentWebshopItem == value)
                    return;
                _currentWebshopItem = value;
                RaisePropertyChanged("CurrentWebshopItem");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Constructors
        public WebshopViewModel()
        {
            WebshopItems = new ObservableCollection<WebshopItem>();
            //should previous cart => nog kijken voor local storage save
            Cart = LoginSingleton.Cart;
            GetConsumablesFromAPI();
        }
        #endregion

        #region Methods
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
            Cart.OrderLines.Remove(orderLine);
        }

        public void ClearCart()
        {
            Cart = new Order();
        }

        public void AddToShoppingCart(WebshopItem webshopItem)
        {
            OrderLine o = Cart.OrderLines.FirstOrDefault(ol => ol.Consumable.ConsumableId == webshopItem.Consumable.ConsumableId);
            if (o == null)
                Cart.OrderLines.Add(new OrderLine(webshopItem.Amount, webshopItem.Consumable, Cart));
            else
                o.Amount += webshopItem.Amount;
            webshopItem.ResetAmount();

        }
        #endregion
    }
}
