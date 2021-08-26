using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherBL
{
    public static class Extensions
    {
        public static double GetCelsius(this Double temperature)
        {
            return temperature - 273.15;
        }
    }
}
