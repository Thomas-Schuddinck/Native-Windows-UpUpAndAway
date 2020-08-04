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
using UpUpAndAwayApp.Models.ListItemModels;

namespace UpUpAndAwayApp.ViewModels
{
    public class SeatManagementViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<Passenger> Passengers { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }

        public Passenger ChosenPassenger { get; set; }

        public PassengerSeat ChosenSeat { get; set; }

        public string SelectedPassenger => ChosenPassenger == null ? "" : $"{ChosenPassenger.FullName} : Seat {Seats.Single(s => s.Passenger.PassengerId == ChosenPassenger.PassengerId).SeatId}";

        public string SwappedTo => ChosenSeat == null ? "" : $"Seat {ChosenSeat.Seat.SeatId} {(ChosenSeat.Passenger == null ? "is empty" : $"belongs to {ChosenSeat.Passenger.FullName}")}.";

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
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Seat"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);
            lst.ToList().ForEach(i => Seats.Add(i));
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
