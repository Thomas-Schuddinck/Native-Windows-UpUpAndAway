using Shared.Models;

namespace Shared.DisplayModels.Singleton
{
    public class LoginSingleton
    {
        private static readonly LoginSingleton instance = new LoginSingleton();
        public static Passenger passenger;
        public static DisplayReduction Cart = new DisplayReduction();

        public static string passengerGroupId { get; private set; }

        private LoginSingleton()
        {
        }
        public void login(Passenger p) { passenger = p; }
        public void joinGroup(string id) { passengerGroupId = id; }
        public static LoginSingleton GetInstance() => instance;
    }
}
