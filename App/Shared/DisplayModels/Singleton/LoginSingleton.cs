using Shared.Models;

namespace Shared.DisplayModels.Singleton
{
    public class LoginSingleton
    {
        private static readonly LoginSingleton instance = new LoginSingleton();
        public static Passenger passenger;
        public static DisplayOrder Cart = new DisplayOrder();
        private LoginSingleton()
        {
        }
        public void login(Passenger p) { passenger = p; }
        public static LoginSingleton GetInstance() => instance;
    }
}
