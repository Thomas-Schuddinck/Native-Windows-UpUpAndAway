using Newtonsoft.Json;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    class SeatManagementViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Passenger> Passengers { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }

        public Passenger ChosenPassenger { get; set; }

        public Seat ChosenSeat { get; set; }

        public Passenger PassengerSwappedWith { get; set; }

        public SeatManagementViewModel()
        {
            Passengers = new ObservableCollection<Passenger>();
            Seats = new ObservableCollection<Seat>();

            GetPassengersFromAPI();
            GetSeatsFromAPI();
        }

        private async void GetSeatsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Consumable"));
            //var lst = JsonConvert.DeserializeObject<ObservableCollection<PassengerDTO>>(json);
            //lst.ToList().ForEach(i => Items.Add(new ReductionItem(new Consumable(i), this)));
        }

        private async void GetPassengersFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Passenger"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Passenger>>(json);
            lst.ToList().ForEach(i => Passengers.Add(i));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
