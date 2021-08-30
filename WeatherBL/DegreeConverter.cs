using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherBL
{
    public static class DegreeConverter
    {
        public static double GetCelsius(double temperature)
        {
            return temperature - 273.15;
        }
    }
}
