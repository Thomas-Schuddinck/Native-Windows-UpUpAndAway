using Newtonsoft.Json;
using Shared.DisplayModels.Singleton;
using Shared.DTOs;
using Shared.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class PassengerViewModel
    {
        public Passenger Passenger { get; private set; }
        LoginSingleton loggedIn = LoginSingleton.GetInstance();

        public PassengerViewModel()
        {
        }

        public async Task LoginPassenger(string id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GeneratePassengerRequestString(id))).ConfigureAwait(false);
                var passenger = new Passenger(JsonConvert.DeserializeObject<PassengerDTO>(jsonResponse));
                this.Passenger = passenger;
                loggedIn.login(Passenger);
                var jsonResponseparty = await client.GetStringAsync(new Uri(GeneratePassengerPartyRequestString(id)));
                var party = jsonResponseparty == null ? Passenger.FullName : jsonResponseparty;
                loggedIn.joinGroup(party);
                ChatViewModel model = new ChatViewModel();
                await model.Connect();
            } 
            catch(HttpRequestException e) 
            {
                throw new Exception("connection failed");
            }
            catch(Exception e)
            {
                throw new Exception("Password is wrong");
            }
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
