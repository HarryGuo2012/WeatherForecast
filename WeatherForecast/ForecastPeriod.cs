using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WeatherForecast
{
    class ForecastPeriod:INotifyPropertyChanged
    {
        private string dayPictureUrl;
        private string nightPictureUrl;
        private string weather;
        private string wind;
        private string temperature;
        private string date;

        public string DayPictureUrl
        {
            get
            {
                return dayPictureUrl;
            }
            set
            {
                if (value != dayPictureUrl)
                {
                    dayPictureUrl = value;
                    NotifyPropertyChanged("DayPictureUrl");
                }
            }
        }
        public string NightPictureUrl
        {
            get
            {
                return nightPictureUrl;
            }
            set
            {
                if (value != nightPictureUrl)
                {
                    nightPictureUrl = value;
                    NotifyPropertyChanged("NightPictureUrl");
                }
            }
        }
        public string Weather
        {
            get
            {
                return weather;
            }
            set
            {
                if (value != weather)
                {
                    weather = value;
                    NotifyPropertyChanged("Weather");
                }
            }
        }
        public string Wind
        {
            get
            {
                return wind;
            }
            set
            {
                if (value != wind)
                {
                    wind = value;
                    NotifyPropertyChanged("Wind");
                }
            }
        }
        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value != temperature)
                {
                    temperature = value;
                    NotifyPropertyChanged("Temperature");
                }
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
