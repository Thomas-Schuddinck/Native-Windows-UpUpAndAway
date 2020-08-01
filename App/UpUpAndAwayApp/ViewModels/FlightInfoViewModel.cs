using Newtonsoft.Json;
using Shared.DisplayModels;
using Shared.Models.Singleton;
using System;
using System.ComponentModel;
using System.Net.Http;
using UpUpAndAwayApp.Data;

namespace UpUpAndAwayApp.ViewModels
{
    public class FlightInfoViewModel : INotifyPropertyChanged
    {

        private OpenWeatherMapResponse _weatherMapResponse;

        public OpenWeatherMapResponse Weather
        {
            get { return this._weatherMapResponse; }
            set
            {
                _weatherMapResponse = value;
                Weather.NotifyAllChanges();
                RaisePropertyChanged(nameof(Weather));
            }
        }

        public FlightInfoSingleton flightInfoSingleton;

        public event PropertyChangedEventHandler PropertyChanged;

        public FlightInfoViewModel()
        {
            getWeather();
            flightInfoSingleton = FlightInfoSingleton.GetInstance();
        }

        private async void getWeather()
        {
            using (var client = new HttpClient())
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateWeatherRequestString()));
                Weather = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(jsonResponse);
            }
        }

        private string GenerateWeatherRequestString()
        {
            return String.Format("{0}/data/2.5/weather?q={1}&appid={2}&units=metric{1}", ApiData.baseUriOWM, "Los Angeles", ApiData.apiKeyOWM);
        }

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
