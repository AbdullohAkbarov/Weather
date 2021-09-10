using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherBL.Interfaces
{
    public interface IValidator
    {
        bool Validate(string param);
    }
}
