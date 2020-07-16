using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class WebshopViewModel
    {
        public ObservableCollection<Consumable> Consumables { get; private set; }

        public WebshopViewModel()
        {
        }
    }
}
