using Newtonsoft.Json;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.ListItemModels;

namespace UpUpAndAwayApp.ViewModels
{
    public class SeatManagementViewModel : INotifyPropertyChanged
    {

        //public ObservableCollection<Passenger> Passengers { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }//Static collection of all Seats
        public ObservableCollection<Seat> NonEmptySeats { get; set; }
        public ObservableCollection<Seat> DisplaySeats { get; set; }//FilteredList of seats to show

        private Seat selectedSeat;

        public Seat SelectedSeat
        {
            get => selectedSeat;
            set
            {
                selectedSeat = value;
                FillDisplay(value);
                RaisePropertyChanged(nameof(SelectedSeat));
                RaisePropertyChanged(nameof(ShowSecond));
            }
        }

        private Seat swapTo;

        public Seat SwapTo
        {
            get => swapTo;
            set
            {
                swapTo = value;
                RaisePropertyChanged(nameof(SwapTo));
                RaisePropertyChanged(nameof(CanSave));
            }
        }

        public bool ShowSecond => SelectedSeat != null;
        public bool CanSave => SwapTo != null && ShowSecond;

        public SeatManagementViewModel()
        {
            Seats = new ObservableCollection<Seat>();
            NonEmptySeats = new ObservableCollection<Seat>();
            DisplaySeats = new ObservableCollection<Seat>();

            GetSeatsFromAPI();
        }

        private void FillDisplay(Seat seat)
        {
            DisplaySeats.Clear();
            foreach (var temp in Seats.Where(s => s.SeatId != seat.SeatId).OrderBy(s=> s.SeatId))
                DisplaySeats.Add(temp);

        }

        public async void SaveChanges()
        {
            Debug.WriteLine($"First seat: {SelectedSeat.SeatId}, second seat: {SwapTo.SeatId}");

        }

        private async void GetSeatsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Seat"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);
            lst.ToList().ForEach(i => Seats.Add(i));
            Seats.Where(s => s.Passenger != null).OrderBy(s=> s.SeatId).ToList().ForEach(t => NonEmptySeats.Add(t));
        }

        //private async void GetPassengersFromAPI()
        //{
        //    HttpClient client = new HttpClient();
        //    var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Passenger"));
        //    var lst = JsonConvert.DeserializeObject<ObservableCollection<Passenger>>(json);
        //    lst.ToList().ForEach(i => Passengers.Add(i));
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
