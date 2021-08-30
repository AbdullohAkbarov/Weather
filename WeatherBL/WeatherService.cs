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
        private IWeatherProvider provider;

        public WeatherService(IWeatherProvider provider)
        {
            this.provider = provider;
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            WeatherModel weather;
            try 
            {
                var response = await provider.GetWeatherAsync(city);
                if (response != null)
                {
                    weather = new WeatherModel { City = city, Temperature = DegreeConverter.GetCelsius(response.Main.Temp), IsSuccess = true };
                }
                else
                {
                    weather = new WeatherModel { Error = "Error occured the city can't find." };
                }
            }
            catch(Exception ex)
            {
                weather = new WeatherModel { Error = $"Error occured the city can't find. Error = {ex.Message}" };
            }            

            return weather;
        }
    }
}
