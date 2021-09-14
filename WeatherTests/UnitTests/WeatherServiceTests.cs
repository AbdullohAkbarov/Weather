using Moq;
using NUnit.Framework;
using System;
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
        private WeatherService _service;
        private WeatherService _testService;
        private WeatherService _testProvider;
        private Mock<IWeatherProvider> _mockProvider;
        private Mock<IWeatherProvider> _mockProvide;
        private Mock<IValidator> _mockValidator;
        private Mock<IValidator> _mockValidate;
        private double temp;
        private string city;
        private string emptyCity = "";


        public WeatherServiceTests()
        {
            temp = 300.00;
            city = "Tashkent";
            _mockProvider = new Mock<IWeatherProvider>();
            _mockValidator = new Mock<IValidator>();          
            _mockProvider.Setup(m => m.GetWeatherAsync(city)).ReturnsAsync(new WeatherResponse() { StatusCode = 200, Main = new Main() { Temp = temp } });            
            _mockValidator.Setup(m => m.Validate(city)).Returns(true);
            _service = new WeatherService(_mockProvider.Object, _mockValidator.Object);
        }
        
        [Test]
        public async Task GetCurrentWeatherAsync_CityNameEqualsResponseCityName_ReturnsAreEqual()
        {
            //Arrange

            //Act
            var result = await _service.GetCurrentWeatherAsync(city);

            //Assert
            Assert.AreEqual(result.City, city);
        }

        [Test]
        public async Task GetCurrentWeatherAsync_TempEqualsResponseTemp_ReturnsAreEqual()
        {
            //Arrange

            //Act
            var result = await _service.GetCurrentWeatherAsync(city);

            //Assert
            Assert.AreEqual(result.Temperature, DegreeConverter.GetCelsius(temp));
        }

        [Test]
        public async Task GetCurrentWeatherAsync_ValidatorIsFalse_ReturnsIsSuccessParameterIsFalse()
        {
            //Arrange

            //Act
            var result = await _service.GetCurrentWeatherAsync(emptyCity);

            //Assert
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public async Task GetCurrentWeatherAsync_ResultErrorAreEqualNullReferenceError_ReturnsAreEqual()
        {
            //Arrange
            _mockProvide = new Mock<IWeatherProvider>();
            _mockProvide.Setup(m => m.GetWeatherAsync(emptyCity)).ThrowsAsync(new NullReferenceException());
            _testProvider = new WeatherService(_mockProvide.Object, _mockValidate.Object);

            //Act
            var result = await _testProvider.GetCurrentWeatherAsync(emptyCity);

            //Assert
            Assert.AreEqual(result.Error, "Unspecified Error Occurred. Object reference not set to an instance of an object.");
        }

        [Test]
        public async Task GetCurrentWeatherAsync_ValidatorIsEmpty_ReturnsParameterAreNullZeroFalse()
        {
            //Arrange
            _mockValidate = new Mock<IValidator>();
            _testService = new WeatherService(_mockProvider.Object, _mockValidate.Object);

            //Act
            var result = await _testService.GetCurrentWeatherAsync(city);

            //Assert
            Assert.That(result.City, Is.Null);
            Assert.That(result.Temperature, Is.Zero);
            Assert.That(result.IsSuccess, Is.False);
        }
    }
}
