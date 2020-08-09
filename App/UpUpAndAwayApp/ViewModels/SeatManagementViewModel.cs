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
                FillDisplay();
                RaisePropertyChanged(nameof(SelectedSeat));
                RaisePropertyChanged(nameof(ShowSecond));
                RaisePropertyChanged(nameof(SelectedSeatInformation));
            }
        }

        public bool ShowSecond => SelectedSeat != null;



        public string SelectedSeatInformation => SelectedSeat == null ? "" : $"Selected Seat {SelectedSeat.SeatId} with Passenger {SelectedSeat.Passenger.FullName}";


        private Seat swapTo;
        public Seat SwapTo
        {
            get => swapTo;
            set
            {
                swapTo = value;
                RaisePropertyChanged(nameof(SwapTo));
                RaisePropertyChanged(nameof(CanSave));
                RaisePropertyChanged(nameof(SwapToInformation));
            }
        }

        public bool CanSave => SwapTo != null && ShowSecond;

        public string SwapToInformation => SwapTo == null ? "" : $"Swap to Seat {SwapTo.SeatId}. " + (SwapTo.Passenger == null ? "This Seat is still empty." : $"This Seat belongs to Passenger {SwapTo.Passenger.FullName}");

        public SeatManagementViewModel()
        {
            Seats = new ObservableCollection<Seat>();
            NonEmptySeats = new ObservableCollection<Seat>();
            DisplaySeats = new ObservableCollection<Seat>();

            GetSeatsFromAPI();
        }

        private void FillDisplay()
        {
            DisplaySeats.Clear();
            if (SelectedSeat == null)
                Seats.ToList().ForEach(s => DisplaySeats.Add(s));
            else
                foreach (var temp in Seats.Where(s => s.SeatId != SelectedSeat.SeatId).OrderBy(s => s.SeatId))
                    DisplaySeats.Add(temp);

        }

        public async void SaveChanges()
        {
            var first = SelectedSeat.SeatId;
            var second = SwapTo.SeatId;
            var dto = new SeatSwapDTO { First = first, Second = second };

            var data = JsonConvert.SerializeObject(dto);

            HttpClient client = new HttpClient();
            var res = await client.PutAsync("http://localhost:5000/api/Seat", new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
            var json = await res.Content.ReadAsStringAsync();
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);

            SelectedSeat = null;
            SwapTo = null;
            Seats.Clear();
            lst.OrderBy(s => s.SeatId).ToList().ForEach(s => Seats.Add(s));

            //Recalculate the new non-empty seats
            SetNonEmptySeats();
        }

        private async void GetSeatsFromAPI()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:5000/api/Seat"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);
            Seats.Clear();
            lst.ToList().ForEach(i => Seats.Add(i));
            SetNonEmptySeats();
        }

        private void SetNonEmptySeats()
        {
            NonEmptySeats.Clear();
            Seats.Where(s => s.Passenger != null).OrderBy(s => s.SeatId).ToList().ForEach(t => NonEmptySeats.Add(t));
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
