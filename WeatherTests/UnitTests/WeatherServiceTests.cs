using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using WeatherBL;
using WeatherBL.Interfaces;
using WeatherBL.Models;
using WeatherBL.Validators;
using WeatherDAL;
using WeatherDAL.Models;

namespace WeatherTests.UnitTests
{
    [TestFixture]
    public class WeatherServiceTests
    {       
        private WeatherService service;
        private Mock<IWeatherProvider> mockProvider;
        private Mock<IValidator> mockValidator;
        private double temp;
        private string city;
        

        public WeatherServiceTests()
        {
            temp = 300.00;
            city = "Tashkent";
            mockProvider = new Mock<IWeatherProvider>();
            mockValidator = new Mock<IValidator>();
        }

        [Test]
        public async Task GetCurrentWeatherAsync_CityNameEqualsResponseCityName_ReturnsTrue()
        {
            //Arrange
            mockProvider.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse() { StatusCode = 200, Main = new Main() { Temp = temp }});
            mockValidator.Setup(m => m.Validate(city)).Returns(true);
            service = new WeatherService(mockProvider.Object, mockValidator.Object);

            //Act
            var result = await service.GetCurrentWeatherAsync(city);

            //Assert
            Assert.AreEqual(result.City, city);
        }

        [Test]
        public async Task GetCurrentWeatherAsync_TempEqualsResponseTemp_ReturnsTrue()
        {
            //Arrange
            mockProvider.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse() { StatusCode = 200, Main = new Main() { Temp = temp }});
            mockValidator.Setup(m => m.Validate(city)).Returns(true);
            service = new WeatherService(mockProvider.Object, mockValidator.Object);

            //Act
            var result = await service.GetCurrentWeatherAsync(city);

            //Assert
            Assert.AreEqual(result.Temperature, DegreeConverter.GetCelsius(temp));
        }
    }
}
