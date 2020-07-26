using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.Models.Singleton
{
    public class LoginSingleton
    {
        private static readonly LoginSingleton instance = new LoginSingleton();
        public static Passenger passenger;
        public static Order Cart = new Order();
        public static string passengerGroupId;
        private LoginSingleton()
        {
        }
        public void login(Passenger p) { passenger = p; }
        public void joinGroup(string id) { passengerGroupId = id; }
        public static LoginSingleton GetInstance() => instance;
    }
}
