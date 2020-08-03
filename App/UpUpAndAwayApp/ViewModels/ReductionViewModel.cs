using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public ObservableCollection<ReductionItem> Items { get; set; }

        public ReductionViewModel()
        {
            Items = new ObservableCollection<ReductionItem>();
            GetConsumablesFromAPI();
            
        }

        private async Task GetConsumablesFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Consumable"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<ConsumableDTO>>(json);
            lst.ToList().ForEach(i => Items.Add(new ReductionItem(new Consumable(i), this)));
        }

        public void SendChanges()
        {
            Debug.WriteLine("Sent");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
