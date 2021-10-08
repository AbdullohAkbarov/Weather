using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL.Models
{
    public class TimerConfig
    {
        public List<string> Cities { get; set; }
        public int Period { get; set; }
    }
}
