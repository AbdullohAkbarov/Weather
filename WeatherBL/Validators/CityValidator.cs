using System;
using System.Collections.Generic;
using System.Text;
using WeatherBL.Interfaces;

namespace WeatherBL.Validators
{
    public class CityValidator: IValidator
    {
        public bool Validate(string city)
        {
            return !string.IsNullOrEmpty(city);
        }
    }
}
