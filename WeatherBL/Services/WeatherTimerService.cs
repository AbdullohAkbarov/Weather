using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherBL.Interfaces;
using WeatherDAL;
using WeatherDAL.Models;

namespace WeatherBL.Services
{
    public class WeatherTimerService: IWeatherTimerService
    {
        private readonly IWeatherProvider _provider;
        private readonly IValidator _validator;
        private readonly TimerConfig _config;
        private static Timer CheckTimer;
        private double temp;

        public WeatherTimerService(IWeatherProvider provider, IValidator validator, TimerConfig config)
        {
            _provider = provider;
            _validator = validator;
            _config = config;

            CheckTimer = new Timer(new TimerCallback(InsertWeatherByTimer));
            CheckTimer.Change(0, config.Period);
        }

        public async void InsertWeatherByTimer(object sender)
        {
            foreach (var city in _config.Cities)
            {
                var response = await _provider.GetWeatherAsync(city);
                if (response != null && response.StatusCode is 200 && _validator.Validate(city))
                {
                    await _provider.InsertWeatherAsync(city, DegreeConverter.GetCelsius(response.Main.Temp));
                }
            }
        }
    }
}
