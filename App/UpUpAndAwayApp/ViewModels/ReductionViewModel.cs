using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.DisplayModels.Singleton;
using Shared.DTOs;
using Shared.Models;
using UpUpAndAwayApp.Models.ListItemModels;

namespace UpUpAndAwayApp.ViewModels
{
    public class ReductionViewModel : INotifyPropertyChanged
    {
        #region Fields
        //private ReductionItem _currentWebshopItem;
     
        #endregion

        #region Properties
        public ObservableCollection<ReductionItem> ReductionItems { get; private set; }


        //public WebshopItem CurrentWebshopItem
        //{
        //    get { return this._currentWebshopItem; }
        //    set
        //    {
        //        if (_currentWebshopItem == value)
        //            return;
        //        _currentWebshopItem = value;
        //        RaisePropertyChanged(nameof(CurrentWebshopItem));
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Constructors
        public ReductionViewModel()
        {
            ReductionItems = new ObservableCollection<ReductionItem>();
            //should previous cart => nog kijken voor local storage save
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
            var lst = JsonConvert.DeserializeObject<ObservableCollection<ConsumableDTO>>(json);
            lst.ToList().ForEach(i => ReductionItems.Add(new ReductionItem(new Consumable(i), this)));
        }

        //public async void SendOrder()
        //{
        //    var test = LoginSingleton.GetInstance();
        //    var order = JsonConvert.SerializeObject(new OrderDTO(Cart, LoginSingleton.passenger));

        //    HttpClient client = new HttpClient();
        //    var res = await client.PostAsync("http://localhost:5000/api/Order", new StringContent(order, System.Text.Encoding.UTF8, "application/json"));
        //}



        //public void AddToShoppingCart(WebshopItem webshopItem)
        //{
        //    DisplayOrderLine o = Cart.OrderLines.FirstOrDefault(ol => ol.Consumable.ConsumableId == webshopItem.Consumable.ConsumableId);
        //    if (o == null)
        //        Cart.OrderLines.Add(new DisplayOrderLine(webshopItem.Amount, webshopItem.Consumable, Cart));
        //    else
        //        o.Amount += webshopItem.Amount;
        //    webshopItem.ResetAmount();

        //}
        #endregion
    }
}
