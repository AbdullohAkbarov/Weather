using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherBL.Validators;

namespace WeatherTests.UnitTests
{
    [TestFixture]
    public class CityValidatorTests
    {
        [Test]
        public void Validate_CityIsNotNull_True()
        {
            //Arrange
            var city = "London";
            var cityValidator = new CityValidator();

            //Act
            var result = cityValidator.Validate(city);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Validate_CityIsNull_False()
        {
            //Arrange
            string city = null;
            var cityValidator = new CityValidator();

            //Act
            var result = cityValidator.Validate(city);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
