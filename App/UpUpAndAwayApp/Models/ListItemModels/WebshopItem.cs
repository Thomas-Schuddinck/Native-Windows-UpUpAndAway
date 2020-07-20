using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.ViewModels;

namespace UpUpAndAwayApp.Models.ListItemModels
{
    public class WebshopItem
    {
        public Consumable Consumable { get; set; }
        public int Amount { get; set; }

        public WebshopViewModel WebshopViewModel { get; set; }

        public WebshopItem(Consumable consumable, WebshopViewModel webshopViewModel)
        {
            Consumable = consumable;
            WebshopViewModel = webshopViewModel;
            ResetAmount();
        }
        
        public void ResetAmount()
        {
            Amount = 0;
        }
    }
}
