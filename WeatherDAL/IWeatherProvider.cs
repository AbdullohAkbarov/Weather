using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherDAL.Models;

namespace WeatherDAL
{
    public interface IWeatherProvider
    {     
        Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
