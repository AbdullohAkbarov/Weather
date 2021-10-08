using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherDAL;
using WeatherDAL.Entities;

namespace WeatherBL.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherProvider _provider;
        private readonly IValidator _validator;
        private double temp;


        public WeatherService(IWeatherProvider provider, IValidator validator)
        {
            _provider = provider;
            _validator = validator;
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            WeatherModel weather;
            try
            {
                var response = await _provider.GetWeatherAsync(city);
                if (response != null && response.StatusCode is 200 && _validator.Validate(city))
                {
                    temp = DegreeConverter.GetCelsius(response.Main.Temp);

                    weather = new WeatherModel { City = city, Temperature = temp, IsSuccess = true };

                    await _provider.InsertWeatherAsync(city, temp);
                }
                else
                {
                    weather = new WeatherModel { Error = "Error occured the city can't be found." };
                }
            }
            catch (Exception ex)
            {
                weather = new WeatherModel { Error = $"Unspecified Error Occurred. {ex.Message}" };
            }

            return weather;
        }

        public async Task<List<Weather>> GetCurrentWeatherHistoryAsync(string city)
        {
            return await _provider.GetWeatherHistoryAsync(city);
        }
    }
}
