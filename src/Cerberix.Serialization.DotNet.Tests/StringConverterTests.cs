using System;
using NUnit.Framework;

namespace Cerberix.Serialization.DotNet.Tests
{
    [TestFixture]
    public class StringConverterTests
    {
        [Test]
        public void WhenGivenNullObjectToStringExpectArgumentNullExceptionThrown()
        {
            // arrange
            const object given = null;

            // act
            var converter = new DotNetStringConverter();

            // assert
            Assert.Throws<ArgumentNullException>(() => converter.ToString(given));
        }

        [Test]
        public void WhenGivenNullStringToStringExpectArgumentNullExceptionThrown()
        {
            // arrange
            const string given = null;

            // act
            var converter = new DotNetStringConverter();

            // assert
            Assert.Throws<ArgumentNullException>(() => converter.ToString(given));
        }

        [Test]
        public void WhenGivenEmptyStringToStringExpectEmptyString()
        {
            // arrange
            const string given = "";
            const string expected = "";

            // act
            var converter = new DotNetStringConverter();
            var actual = converter.ToString(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void WhenGivenIntegerObjectToStringExpectStringResult()
        {
            // arrange
            const int given = 666;
            const string expected = "666";

            // act
            var converter = new DotNetStringConverter();
            var actual = converter.ToString(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void WhenGivenDecimalObjectToStringExpectStringResult()
        {
            // arrange
            const decimal given = 666.67m;
            const string expected = "666.67";

            // act
            var converter = new DotNetStringConverter();
            var actual = converter.ToString(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void WhenGivenDoubleObjectToStringExpectStringResult()
        {
            // arrange
            const double given = 666.67;
            const string expected = "666.67";

            // act
            var converter = new DotNetStringConverter();
            var actual = converter.ToString(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }
    }
}