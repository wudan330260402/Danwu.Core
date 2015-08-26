using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.ObserverPattern
{
    /// <summary>
    /// 观察者接口
    /// </summary>
    public interface IObserver
    {
        void Update(WeatherData data);
    }

    /// <summary>
    /// 显示器接口
    /// </summary>
    public interface IDisplayElement {

        void Display();

    }

    /// <summary>
    /// 第一块显示器
    /// </summary>
    public class FirstDisplayElement : IDisplayElement, IObserver {

        private WeatherData weatherData;

        public void Update(WeatherData data)
        {
            weatherData = data;
            Display();
        }

        public void Display() {
            Console.WriteLine("FirstDisplayElement==》{0}", weatherData.ToString());
        }

    }
}
