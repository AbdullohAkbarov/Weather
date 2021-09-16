using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Validators;
using WeatherDAL;

namespace WeatherTests.IntegrationTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        private WeatherService _service;
        //private WeatherProvider _provider;
        //private CityValidator _cityValidator;
        //private HttpClient client;
        private string url;
        private string appid;
        private string city;
        private string emptyCity;


        public WeatherServiceTests()
        {
            url = "https://api.openweathermap.org/data/2.5/weather";
            appid = "645958578ad07af2944914edc4469d13";
            city = "Tashkent";
            _service = new WeatherService(new WeatherProvider(new HttpClient(), url, appid), new CityValidator());
        }

        [Test]
        public async Task GetCurrentWeatherAsync_CityName_ReturnsTemp()
        {
            //Arrange

            //Act
            var result = await _service.GetCurrentWeatherAsync(city);

            //Assert
            //Assert.IsTrue(Regex.Match(result.Temperature, "^[0-9]*[.][0-9]*$"));
            Assert.IsNotNull(result.City);
            Assert.IsNotNull(result.Temperature);
            Assert.IsNull(result.Error);
        }

        //[Test]
        //public async Task GetCurrentWeatherAsync_Temp_ReturnsSameTemp()
        //{
        //    //Arrange

        //    //Act
        //    var result = await _service.GetCurrentWeatherAsync(city);

        //    //Assert
        //    Assert.AreEqual(result.Temperature, DegreeConverter.GetCelsius(temp));
        //}

        //[Test]
        //public async Task GetCurrentWeatherAsync_ValidatorIsFalse_ReturnsIsSuccessParameterIsFalse()
        //{
        //    //Arrange

        //    //Act
        //    var result = await _service.GetCurrentWeatherAsync(emptyCity);

        //    //Assert
        //    Assert.That(result.IsSuccess, Is.False);
        //    Assert.AreEqual(result.Error, "Error occured the city can't be found.");
        //}

        //[Test]
        //public async Task GetCurrentWeatherAsync_ErrorNullReferenceError_ReturnsSameError()
        //{
        //    //Arrange

        //    //Act
        //    var result = await _testProvider.GetCurrentWeatherAsync(emptyCity);

        //    //Assert
        //    Assert.AreEqual(result.Error, "Unspecified Error Occurred. Object reference not set to an instance of an object.");
        //}

        //[Test]
        //public async Task GetCurrentWeatherAsync_ValidatorIsEmpty_ReturnsParametersAreNull()
        //{
        //    //Arrange

        //    //Act
        //    var result = await _testService.GetCurrentWeatherAsync(city);

        //    //Assert
        //    Assert.That(result.City, Is.Null);
        //    Assert.That(result.Temperature, Is.Zero);
        //    Assert.That(result.IsSuccess, Is.False);
        //}
    }
}
