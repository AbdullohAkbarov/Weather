using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherBL.Models
{
    public class Weather
    {
        public Weather(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public Weather(string city, double temperature, bool isSuccess)
        {
            City = city;
            Temperature = temperature;
            IsSuccess = isSuccess;
        }

        public string City { get; set; }
        public double Temperature { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
