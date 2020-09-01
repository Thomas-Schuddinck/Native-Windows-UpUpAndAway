using Shared.Models;

namespace Shared.DisplayModels.Singleton
{
    public class LoginSingleton
    {
        private static readonly LoginSingleton instance = new LoginSingleton();
        public static Passenger passenger;
        public Seat seat;
        public static DisplayOrder Cart = new DisplayOrder();

        public string PassengerGroupId { get; set; }

        private LoginSingleton()
        {
        }
        public void login(Passenger p) { passenger = p; }
        public void orderSeat(Seat s) { seat = s; }
        public static LoginSingleton GetInstance() => instance;
    }
}
