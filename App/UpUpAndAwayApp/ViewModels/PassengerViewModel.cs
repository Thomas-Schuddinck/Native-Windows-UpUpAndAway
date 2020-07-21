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
        LoginSingleton login = LoginSingleton.GetInstance();

        public PassengerViewModel()
        {
        }

        public async Task LoginPassenger(string id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GeneratePassengerRequestString(id)));
                var passenger = JsonConvert.DeserializeObject<Passenger>(jsonResponse);
                this.Passenger = passenger;
                login.login(Passenger);
                ChatViewModel model = new ChatViewModel();
                await model.Connect();
            } 
            catch(HttpRequestException e) 
            {
                throw new Exception("connection failed");
            }
        }

        private string GeneratePassengerRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/passenger/{0}", id);
        }
    }
}
