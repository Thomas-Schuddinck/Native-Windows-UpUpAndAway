using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.Singleton;

namespace UpUpAndAwayApp.ViewModels
{
    public class PassengerViewModel
    {
        public Passenger Passenger { get; private set; }
        LoginSingleton loggedIn = LoginSingleton.GetInstance();

        public PassengerViewModel()
        {
        }

        public async void LoginPassenger(string id)
        {
            HttpClient client = new HttpClient();
            var jsonResponsePassenger = await client.GetStringAsync(new Uri(GeneratePassengerRequestString(id)));
            var passenger = JsonConvert.DeserializeObject<Passenger>(jsonResponsePassenger);
            this.Passenger = passenger; 
            loggedIn.login(Passenger);
            var jsonResponseparty = await client.GetStringAsync(new Uri(GeneratePassengerPartyRequestString(id)));
            var party = jsonResponseparty == null ? Passenger.FullName : jsonResponseparty;
            loggedIn.joinGroup(party);
            ChatViewModel model = new ChatViewModel();
            await model.Connect();
        }

        private string GeneratePassengerRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/passenger/{0}", id);
        }

        private string GeneratePassengerPartyRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/passenger/party/{0}", id);
        }
    }
}
