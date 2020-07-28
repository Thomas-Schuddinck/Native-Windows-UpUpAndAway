using System;
using System.Collections.Generic;

namespace Shared.DisplayModels
{
    public class OpenWeatherMapResponse
    {
        public string Name { get; set; }

        public ICollection<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }

        public Wind Wind { get; set; }

        public string NameAdapter => "Weather in " + Name;
        public string WindAdapter => "Windspeed: " + Wind.Speed;
        public string TempAdapter => "Temperature: " + (Main.Temp - 272.15) + "°C" ;
        public string HumidityAdapter => "Humidity: " + Main.Humidity + "%";
        public string GeneralWeatherAdapter => string.Join(", ", GetGeneralWeather());
        public string DateAdapter => DateTime.Now.DayOfWeek.ToString() + " " + DateTime.Now.ToUniversalTime().AddHours(-7).ToShortTimeString();


        public List<string> GetGeneralWeather()
        {
            List<string> res = new List<string>();
            foreach(WeatherDescription wd in Weather)
            {
                res.Add(string.Format("{0} ({1})", wd.Main, wd.Description));
            }
            return res;
        }

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
