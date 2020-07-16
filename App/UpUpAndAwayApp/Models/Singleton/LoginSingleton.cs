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
        private LoginSingleton()
        {
        }
        public void login(Passenger p) { passenger = p; }
        public static LoginSingleton GetInstance() => instance;
    }
}
