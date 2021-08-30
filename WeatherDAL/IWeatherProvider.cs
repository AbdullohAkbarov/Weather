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
        HttpClient Client { get; set; }
        WeatherResponse WeatherResponse { get; set; }
        string Appid { get; set; }
        string Url { get; set; }        

        Task<WeatherResponse> GetWeatherAsync(string city);
    }
}
