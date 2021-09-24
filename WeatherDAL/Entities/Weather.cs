using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDAL.Entities
{
    public class Weather
    {
        public int Id { get; set; }
        public string City{ get; set; }
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
    }
}
