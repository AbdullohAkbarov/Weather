using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Models;
using WeatherDAL;
using WeatherDAL.Models;

namespace WeatherTests.UnitTests
{
    public class WeatherServiceTests
    {
        private WeatherService service;
        private string city = "Tashkent";

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IWeatherProvider>();
            mock.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse());
            service = new WeatherService(mock.Object);
        }

        [Test]
        public async void GetCurrentWeatherAsync_IsInstanceOf_AssertFailedException()
        {
            var result = await service.GetCurrentWeatherAsync(city);

            Assert.IsInstanceOf<WeatherModel>(result);
        }

        [Test]
        public async void GetCurrentWeatherAsync_IsNotNull_NullReferenceException()
        {
            var result = await service.GetCurrentWeatherAsync(city);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.City);
            Assert.IsNotNull(result.Temperature);
        }

        [Test]
        public async void GetCurrentWeatherAsync_CityEqualsCity_Boolean()
        {
            var result = await service.GetCurrentWeatherAsync(city);

            Assert.Equals(result.City, city);
        }
    }
}
