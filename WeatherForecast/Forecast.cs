using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.IO;

namespace WeatherForecast
{
    /// <summary>
    /// 天气异步请求类
    /// </summary>
    class Forecast:INotifyPropertyChanged
    {
        private string date;
        private string currentCity;
        public ObservableCollection<ForecastPeriod> ForecastList
        {get;set;}
        //绑定部分
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if(value!=date)
                {
                    date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }
        public string CurrentCity
        {
            get
            {
                return currentCity;
            }
            set
            {
                if(value!=currentCity)
                {
                    currentCity = value;
                    NotifyPropertyChanged("CurrentCity");
                }
            }
        }
        public Forecast()
        {
            ForecastList=new ObservableCollection<ForecastPeriod>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        ////////////////////////////////////////////////////////////////
        public async void getForecast(string name)
        {
            Uri uri = new Uri("http://api.map.baidu.com/telematics/v3/weather?location=" + name + "&output=xml&ak=588E04Bb9dff95138605dc99547817d6");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            Stream stream = await response.Content.ReadAsStreamAsync();

            string currentCity = "";
            string date = "";
            ObservableCollection<ForecastPeriod> newForecastList =new ObservableCollection<ForecastPeriod>();

            XElement xmlWeather = XElement.Load(stream);
            date = xmlWeather.Element("date").Value;
            xmlWeather = xmlWeather.Element("results");
            currentCity = xmlWeather.Element("currentCity").Value;

            ForecastPeriod newForecastPeriod = new ForecastPeriod();
            XElement curElement = xmlWeather.Element("weather_data").Element("date");
            while (curElement != null) 
            {
                if (curElement.Name.LocalName.Equals("date"))
                    newForecastPeriod.Date = curElement.Value;
                else if (curElement.Name.LocalName.Equals("dayPictureUrl"))
                    newForecastPeriod.DayPictureUrl = curElement.Value;
                else if (curElement.Name.LocalName.Equals("nightPictureUrl"))
                    newForecastPeriod.NightPictureUrl = curElement.Value;
                else if (curElement.Name.LocalName.Equals("weather"))
                    newForecastPeriod.Weather = curElement.Value;
                else if (curElement.Name.LocalName.Equals("wind"))
                    newForecastPeriod.Wind = curElement.Value;
                else if (curElement.Name.LocalName.Equals("temperature"))
                {    
                    newForecastPeriod.Temperature = curElement.Value;
                    newForecastList.Add(newForecastPeriod);
                    newForecastPeriod = new ForecastPeriod();
                }
                curElement = (XElement)curElement.NextNode;
            }
            CurrentCity = currentCity;
            Date = date;
            foreach (ForecastPeriod forecastPeriod in newForecastList)
                ForecastList.Add(forecastPeriod);
        }
    }
}
