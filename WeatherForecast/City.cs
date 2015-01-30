using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WeatherForecast
{
    /// <summary>
    /// 城市绑定类
    /// </summary>
    public class City:INotifyPropertyChanged
    {
        private string name;
        private string province;
        /// <summary>
        /// 城市名
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(name!=value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        /// <summary>
        /// 省份名
        /// </summary>
        public string Province
        {
            get
            {
                return province;
            }
            set
            {
                if(province!=value)
                {
                    province = value;
                    NotifyPropertyChanged("Province");
                }
            }
        }
        /// <summary>
        /// City构造函数
        /// </summary>
        /// <param name="cityName">城市名称</param>
        /// <param name="cityProvince">城市省份</param>
        public City(string cityName,string cityProvince)
        {
            Name = cityName;
            Province = cityProvince;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 用于绑定属性值改变触发的事件，动态改变
        /// </summary>
        /// <param name="property">改动值</param>
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
