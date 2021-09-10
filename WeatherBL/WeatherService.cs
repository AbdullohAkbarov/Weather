using System;
using System.Threading.Tasks;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherProvider provider;
        private readonly IValidator validator;


        public WeatherService(IWeatherProvider provider, IValidator validator)
        {
            this.provider = provider;
            this.validator = validator;
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            WeatherModel weather;
            try
            {
                var response = await provider.GetWeatherAsync(city);
                if (response != null && response.StatusCode is 200 && validator.Validate(city))
                {
                    weather = new WeatherModel { City = city, Temperature = DegreeConverter.GetCelsius(response.Main.Temp), IsSuccess = true };
                }
                else
                {
                    weather = new WeatherModel { Error = "Error occured the city can't be found." };
                }
            }
            catch(Exception ex)
            {
                weather = new WeatherModel { Error = $"Unspecified Error Occurred. {ex.Message}" };
            }            

            return weather;
        }
    }
}
