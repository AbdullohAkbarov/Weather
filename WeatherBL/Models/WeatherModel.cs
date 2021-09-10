using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherBL.Models
{
    public class WeatherModel
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
