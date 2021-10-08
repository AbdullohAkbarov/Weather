using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBL.Interfaces
{
    public interface IWeatherTimerService
    {
        void InsertWeatherByTimer(object sender);
    }
}
