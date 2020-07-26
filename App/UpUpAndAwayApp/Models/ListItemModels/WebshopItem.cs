using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.ViewModels;

namespace UpUpAndAwayApp.Models.ListItemModels
{
    public class WebshopItem : INotifyPropertyChanged
    {
        public int _amount;
        public Consumable Consumable { get; set; }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public WebshopViewModel WebshopViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected void OnPropertyChanged([CallerMemberName] string amount = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(amount));
        }
    }
}
