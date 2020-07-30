using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Shared.DisplayModels
{
    public class OpenWeatherMapResponse : INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private Main _main;
        private Wind _wind;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyAllChanges();
            }
        }
        public ObservableCollection<WeatherDescription> Weather { get; set; }
        public Main Main
        {
            get
            {
                return _main;
            }
            set
            {
                _main = value;
                NotifyAllChanges();
            }
        }
        public Wind Wind
        {
            get
            {
                return _wind;
            }
            set
            {
                _wind = value;
                NotifyAllChanges();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region ReadOnly-Properties
        public string NameAdapter => "Weather in " + Name;
        public string WindAdapter => "Windspeed: " + Wind.Speed;
        public string TempAdapter => "Temperature: " + (Main.Temp - 272.15) + "°C";
        public string HumidityAdapter => "Humidity: " + Main.Humidity + "%";
        public string GeneralWeatherAdapter => string.Join(", ", GetGeneralWeather());
        public string DateAdapter => DateTime.Now.DayOfWeek.ToString() + " " + DateTime.Now.ToUniversalTime().AddHours(-7).ToShortTimeString();
        #endregion

        #region Constructors
        public OpenWeatherMapResponse()
        {

        } 
        #endregion

        #region Methods
        public List<string> GetGeneralWeather()
        {
            List<string> res = new List<string>();
            foreach (WeatherDescription wd in Weather)
            {
                res.Add(string.Format("{0} ({1})", wd.Main, wd.Description));
            }
            return res;
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void NotifyAllChanges()
        {
            RaisePropertyChanged(nameof(Name));
            RaisePropertyChanged(nameof(Main));
            RaisePropertyChanged(nameof(Wind));
            RaisePropertyChanged(nameof(NameAdapter));
            RaisePropertyChanged(nameof(WindAdapter));
            RaisePropertyChanged(nameof(TempAdapter));
            RaisePropertyChanged(nameof(HumidityAdapter));
            RaisePropertyChanged(nameof(GeneralWeatherAdapter));
            RaisePropertyChanged(nameof(DateAdapter));
        } 
        #endregion

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
