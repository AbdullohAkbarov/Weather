using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
