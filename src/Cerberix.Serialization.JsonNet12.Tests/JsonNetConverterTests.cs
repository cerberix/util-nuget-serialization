using System;
using NUnit.Framework;

namespace Cerberix.Serialization.JsonNet12.Tests
{
    [TestFixture]
    public class JsonNetConverterTests
    {
        [Test]
        public void WhenGivenNullObjectToSerializeExpectNullStringResult()
        {
            // arrange
            const object given = null;
            const string expected = null;

            // act
            var converter = new JsonNetConverter();
            var actual = converter.Serialize(given);

            // assert
            Assert.IsNull(expected);
        }

        [Test]
        public void WhenGivenNullStringToSerializeExpectNullStringResult()
        {
            // arrange
            const string given = null;
            const string expected = null;

            // act
            var converter = new JsonNetConverter();
            var actual = converter.Serialize(given);

            // assert
            Assert.IsNull(expected);
        }

        [Test]
        public void WhenGivenEmptyStringToSerializeExpectJsonStringResult()
        {
            // arrange
            const string given = "";
            const string expected = "\"\"";

            // act
            var converter = new JsonNetConverter();
            var actual = converter.Serialize(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void WhenGivenNullStringToDeserializeAsObjectExpectArgumentNullExceptionThrown()
        {
            // arrange
            const string given = null;

            // act
            var converter = new JsonNetConverter();

            // assert
            Assert.Throws<ArgumentNullException>(() => converter.Deserialize<object>(given));
        }

        [Test]
        public void WhenGivenNullStringToDeserializeAsStringExpectArgumentNullExceptionThrown()
        {
            // arrange
            const string given = null;

            // act
            var converter = new JsonNetConverter();

            // assert
            Assert.Throws<ArgumentNullException>(() => converter.Deserialize<string>(given));
        }

        [Test]
        public void WhenGivenEmptyStringToDeserializeAsStringExpectNullStringResult()
        {
            // arrange
            const string given = "";
            const string expected = null;

            // act
            var converter = new JsonNetConverter();
            var actual = converter.Deserialize<string>(given);

            // assert
            Assert.IsNull(expected);
        }

        [Test]
        public void WhenGivenJsonStringToDeserializeAsStringExpectEmptyStringResult()
        {
            // arrange
            const string given = "\"\"";
            const string expected = "";

            // act
            var converter = new JsonNetConverter();
            var actual = converter.Deserialize<string>(given);

            // assert
            Assert.IsNotNull(expected);
            Assert.AreEqual(expected: expected, actual: actual);
        }
    }
}
