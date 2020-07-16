using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.Models.Singleton
{
    class LoginSingleton
    {
        private static readonly LoginSingleton instance = new LoginSingleton();
        public Passenger Passenger;
        private LoginSingleton()
        {
        }
        public static void SetPassenger(Passenger passenger) { this.Passenger = passenger; }
        public static LoginSingleton GetInstance() => instance;
    }
}
