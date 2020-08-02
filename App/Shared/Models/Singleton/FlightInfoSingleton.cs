using System;

namespace Shared.Models.Singleton
{
    public class FlightInfoSingleton 
    {
        private static readonly FlightInfoSingleton instance = new FlightInfoSingleton();
        public string flightcode = "123 - 4567 - 89";
        public string origin = "Brussels (Belgium)";
        public string destination = "Los Angeles (US)";
        public DateTime arrivalTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 25, 00);
        public string airline = "Brussels Airlines";

        public static FlightInfoSingleton GetInstance() => instance;

        private FlightInfoSingleton() { }
    }
}
