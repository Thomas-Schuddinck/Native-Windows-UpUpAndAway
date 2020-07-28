using Newtonsoft.Json;
using Shared.DisplayModels;
using System;
using System.Net.Http;
using UpUpAndAwayApp.Data;

namespace UpUpAndAwayApp.ViewModels
{
    public class FlightInfoViewModel
    {
        public OpenWeatherMapResponse Weather { get; private set; }

        public FlightInfoViewModel()
        {
            getWeather();
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
    }
}
