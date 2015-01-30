using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    /// <summary>
    /// 城市集合，继承ObservableCollection<City>
    /// </summary>
    public class Cities:ObservableCollection<City>
    {
        public Cities() { }
        /// <summary>
        /// 默认数据
        /// </summary>
        public void LoadDefaultData()
        {
            this.Add(new City("成都", "四川"));
            this.Add(new City("北京", "北京"));
            this.Add(new City("广州", "广东"));
            this.Add(new City("哈尔滨", "黑龙江"));
        }
    }
}
