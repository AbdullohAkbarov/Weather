using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherBL;
using WeatherBL.Models;

namespace Weather.Tests.WeatherBL
{
    [TestClass]
    public class WeatherServiceTests
    {

        [TestMethod]
        public void GetCurrentWeatherTest()
        {
            //arrange            
            WeatherService service = new WeatherService(url, appid);

            //act
            WeatherModel result = service.GetCurrentWeather(city).Result;

            //assert
            //Assert.
        }
    }
}
