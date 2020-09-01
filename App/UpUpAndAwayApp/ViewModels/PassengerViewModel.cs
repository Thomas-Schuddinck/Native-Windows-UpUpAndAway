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
                if (passenger.PassengerId == -1)
                    throw new ArgumentException("blabla");
                this.Passenger = passenger;
                loggedIn.login(Passenger);
                var jsonResponseparty = await client.GetStringAsync(new Uri(GeneratePassengerPartyRequestString(passenger.PassengerId.ToString())));
                var party = jsonResponseparty == null ? Passenger.FullName : jsonResponseparty;
                loggedIn.PassengerGroupId=party;
                var jsonResponseSeat = await client.GetStringAsync(new Uri(GeneratePassengerSeatRequestString(passenger.PassengerId.ToString()))).ConfigureAwait(false);
                var seat = new Seat(JsonConvert.DeserializeObject<SeatDTO>(jsonResponseSeat));
                loggedIn.orderSeat(seat);
                ChatViewModel model = new ChatViewModel();
                await model.Connect();
            }
            catch (ArgumentException e)
            {
                throw;
            }
            catch (HttpRequestException e) 
            {
                throw new Exception("connection failed");
            }
            catch(Exception e)
            {
                throw new Exception("Password is wrong");
            }
        }

        private string GeneratePassengerRequestString(string seatnr)
        {
            return String.Format("http://localhost:5000/api/passenger/login/{0}", seatnr);
        }

        private string GeneratePassengerSeatRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/Seat/{0}", id);
        }

        private string GeneratePassengerPartyRequestString(string id)
        {
            return String.Format("http://localhost:5000/api/passenger/party/{0}", id);
        }
    }
}
