using Newtonsoft.Json;
using System;
using System.Net.Http;
using UpUpAndAwayApp.Data;
using UpUpAndAwayApp.Models;

namespace UpUpAndAwayApp.ViewModels
{
    public class FlightInfoViewModel
    {
        public OpenWeatherMapResponse Weather { get; private set; }

        public FlightInfoViewModel()
        {
            getWeather();
        }

        public async void getWeather()
        {
            string city = "Los Angeles";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiData.baseUriOWM);
                var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={ApiData.apiKeyOWM}&units=metric");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Weather = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(jsonResponse);

            }
        }
    }
}
