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

        //public ObservableCollection<Passenger> Passengers { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }//Static collection of all Seats
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
                RaisePropertyChanged(nameof(showSecond));
            }
        }

        private void FillDisplay(Seat seat)
        {
            DisplaySeats = new ObservableCollection<Seat>(Seats.Where(s => s.SeatId != seat.SeatId).ToList());
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

        public bool showSecond => SelectedSeat != null;
        public bool CanSave => SwapTo != null && showSecond;

        public SeatManagementViewModel()
        {
            Seats = new ObservableCollection<Seat>();
            Seats.Add(new Seat { SeatId = 69 });
            DisplaySeats = new ObservableCollection<Seat>();

            GetSeatsFromAPI();
        }

        public async void SaveChanges()
        {

        }

        private async void GetSeatsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Seat"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);
            lst.ToList().ForEach(i => Seats.Add(i));
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
