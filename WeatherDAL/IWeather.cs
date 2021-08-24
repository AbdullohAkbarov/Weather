using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL
{
    public interface IWeather
    {
        double CurrentWeather(string url, string appid, string city);
    }
}
