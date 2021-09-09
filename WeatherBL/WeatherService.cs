using System;
using System.Threading.Tasks;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;

namespace WeatherBL
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherProvider provider;
        private CityValidator cityValidator;


        public WeatherService(IWeatherProvider provider)
        {
            this.provider = provider;
            cityValidator = new CityValidator();
        }

        public async Task<WeatherModel> GetCurrentWeatherAsync(string city)
        {
            WeatherModel weather;
            try
            {
                var response = await provider.GetWeatherAsync(city);
                if (response != null && response.StatusCode is 200 && cityValidator.Validate(city))
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
