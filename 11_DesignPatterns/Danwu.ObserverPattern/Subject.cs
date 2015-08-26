using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.ObserverPattern
{
    /// <summary>
    /// 主题接口
    /// </summary>
    public interface Subject {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notify();
    }

    /// <summary>
    /// 气象数据
    /// </summary>
    public class WeatherData
    {
        public String Temperature { get; set; }
        public String Moisture { get; set; }
        public String AirPressure { get; set; }

        public override string ToString()
        {
            return String.Format("Temperature:{0},Moisture:{1},AirPressure:{2}",
                this.Temperature, this.Moisture, this.AirPressure);
        }
    }

    /// <summary>
    /// 气象站
    /// </summary>
    public class WeatherStation : Subject
    {
        private List<IObserver> observers = null;
        public WeatherStation() {
            observers = new List<IObserver>();
        }

        public WeatherData Weather
        {
            get;
            set;
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer)) observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (!observers.Contains(observer)) observers.Remove(observer);
        }

        public void Notify()
        {
            if (observers != null)
                observers.ForEach(o => o.Update(this.Weather));
        }

        public void ChangeWeather(WeatherData weatherData)
        {
            this.Weather = weatherData;
            Notify();
        }
    }
}
