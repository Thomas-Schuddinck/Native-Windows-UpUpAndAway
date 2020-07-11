namespace UpUpAndAwayApp.Models
{
    public class OpenWeatherMapResponse
    {
        public WeatherDescription Weather { get; set; }

        public Main Main { get; set; }

        public Main Wind { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string Humidity { get; set; }
    }

    public class Wind
    {
        public string Speed { get; set; }
    }
}
