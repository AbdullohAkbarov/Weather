using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL.Models
{
    public class Main
    {
        public Main()
        {

        }

        public Main(double temp)
        {
            Temp = temp;
        }

        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
