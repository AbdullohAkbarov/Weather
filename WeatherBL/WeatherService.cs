using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Models;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService : IWeatherService
    {
        private readonly string url;
        private readonly string appid;
        private WeatherModel weather;

        public WeatherService(string url, string appid)
        {
            this.url = url;
            this.appid = appid;
        }

        public async Task<WeatherModel> GetCurrentWeather(string city)
        {
            WeatherProvider provider = new WeatherProvider(appid);

            try 
            {
                var response = await provider.GetWeatherAsync(url, city);
                if (response != null)
                {
                    weather = new WeatherModel(city, response.Main.Temp.GetCelsius(), true);
                }
                else
                {
                    weather = new WeatherModel("Didn't find the city you wrote");
                }
            }
            catch(Exception ex)
            {
                weather = new WeatherModel($"Didn't find the city you wrote. Error = {ex.Message}");
            }            

            return weather;
        }
    }
}
