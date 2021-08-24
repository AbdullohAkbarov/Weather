using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL
{
    public interface IWeather
    {
        string CurrentWeather(string url, string appid, string city);
    }
}
