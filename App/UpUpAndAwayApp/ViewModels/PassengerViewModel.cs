using Newtonsoft.Json;
using Shared.DisplayModels.Singleton;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Net.Http;

namespace UpUpAndAwayApp.ViewModels
{
    public class PassengerViewModel
    {
        public Passenger Passenger { get; private set; }
        LoginSingleton login = LoginSingleton.GetInstance();

        public PassengerViewModel()
        {
        }

        public async void LoginPassenger(string id)
        {
            HttpClient client = new HttpClient();
            var jsonResponse = await client.GetStringAsync(new Uri(GeneratePassengerRequestString(id)));
            var passenger = new Passenger(JsonConvert.DeserializeObject<PassengerDTO>(jsonResponse));
            this.Passenger = passenger;
            login.login(Passenger);
            ChatViewModel model = new ChatViewModel();
            var test = LoginSingleton.GetInstance();
            await model.Connect();
        }

        private string GeneratePassengerRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/passenger/{0}", id);
        }
    }
}
