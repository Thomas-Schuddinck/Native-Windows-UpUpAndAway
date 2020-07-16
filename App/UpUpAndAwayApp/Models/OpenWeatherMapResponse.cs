using System.Collections.Generic;

namespace UpUpAndAwayApp.Models
{
    public class OpenWeatherMapResponse
    {
        public string Name { get; set; }

        public IEnumerable<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Humidity { get; set; }
    }

    public class Wind
    {
        public string Speed { get; set; }
    }
}
