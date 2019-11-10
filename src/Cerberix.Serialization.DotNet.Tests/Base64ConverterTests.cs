using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace Cerberix.Serialization.DotNet.Tests
{
    [TestFixture]
    public class Base64ConverterTests
    {
        private readonly IBase64Converter _Base64Converter;
        private readonly IByteConverter _UTF8Converter;

        public Base64ConverterTests()
        {
            var mockConverter = new Mock<IByteConverter>(MockBehavior.Strict);
            mockConverter.Setup(mc => mc.ConvertToBytes(It.IsAny<string>())).Returns((string input) =>
            {
                return UTF8Encoding.UTF8.GetBytes(input);
            });
            mockConverter.Setup(mc => mc.ConvertToString(It.IsAny<IReadOnlyCollection<byte>>())).Returns((IReadOnlyCollection<byte> input) =>
            {
                return UTF8Encoding.UTF8.GetString(input.ToArray());
            });

            _UTF8Converter = mockConverter.Object;
            _Base64Converter = new DotNetBase64Converter(_UTF8Converter);
        }

        [Test]
        public void When_FromBase64String_GivenNull_ExpectNull()
        {
            var actual = _Base64Converter.FromBase64String(null as string);
            Assert.IsNull(actual);
        }

        [Test]
        public void When_FromBase64Bytes_GivenNull_ExpectNull()
        {
            var actual = _Base64Converter.FromBase64Bytes(null as byte[]);
            Assert.IsNull(actual);
        }

        [Test]
        public void When_ToBase64String_GivenNull_ExpectNull()
        {
            var actual = _Base64Converter.ToBase64String(null as byte[]);
            Assert.IsNull(actual);
        }

        [Test]
        public void When_ToBase64Bytes_GivenNull_ExpectNull()
        {
            var actual = _Base64Converter.ToBase64Bytes(null as string);
            Assert.IsNull(actual);
        }

        [Test]
        public void When_ToBase64Bytes_GivenEmpty_ExpectEmpty()
        {
            // arrange
            const string input = "";
            const string expected = "";

            // act
            var actualBytes = _Base64Converter.ToBase64Bytes(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_ToBase64Bytes_GivenTest1_ExpectResult1()
        {
            // arrange
            const string input = "abc";
            const string expected = "YWJj";

            // act
            var actualBytes = _Base64Converter.ToBase64Bytes(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_ToBase64Bytes_GivenTest2_ExpectResult2()
        {
            // arrange
            const string input = "Ut est etiam invenire maluisset, ea porro debitis indoctum vim, ad eos error invidunt constituto. Eu velit quando fabellas sea. Sea fabellas dignissim at, lorem falli mundi sea eu. Ut eum gloriatur sadipscing, ius te expetenda omittantur";
            const string expected = "VXQgZXN0IGV0aWFtIGludmVuaXJlIG1hbHVpc3NldCwgZWEgcG9ycm8gZGViaXRpcyBpbmRvY3R1bSB2aW0sIGFkIGVvcyBlcnJvciBpbnZpZHVudCBjb25zdGl0dXRvLiBFdSB2ZWxpdCBxdWFuZG8gZmFiZWxsYXMgc2VhLiBTZWEgZmFiZWxsYXMgZGlnbmlzc2ltIGF0LCBsb3JlbSBmYWxsaSBtdW5kaSBzZWEgZXUuIFV0IGV1bSBnbG9yaWF0dXIgc2FkaXBzY2luZywgaXVzIHRlIGV4cGV0ZW5kYSBvbWl0dGFudHVy";

            // act
            var actualBytes = _Base64Converter.ToBase64Bytes(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_ToBase64Bytes_GivenTest3_ExpectResult3()
        {
            // arrange
            const string input = "loción";
            const string expected = "bG9jacOzbg==";

            // act
            var actualBytes = _Base64Converter.ToBase64Bytes(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_FromBase64Bytes_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string input = "";
            const string expected = "";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(input);
            var actual = _Base64Converter.FromBase64Bytes(inputBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_FromBase64Bytes_GivenTest1_ExpectResult1()
        {
            // arrange
            const string input = "YWJj";
            const string expected = "abc";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(input);
            var actual = _Base64Converter.FromBase64Bytes(inputBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_FromBase64Bytes_GivenTest2_ExpectResult2()
        {
            // arrange
            const string input = "VXQgZXN0IGV0aWFtIGludmVuaXJlIG1hbHVpc3NldCwgZWEgcG9ycm8gZGViaXRpcyBpbmRvY3R1bSB2aW0sIGFkIGVvcyBlcnJvciBpbnZpZHVudCBjb25zdGl0dXRvLiBFdSB2ZWxpdCBxdWFuZG8gZmFiZWxsYXMgc2VhLiBTZWEgZmFiZWxsYXMgZGlnbmlzc2ltIGF0LCBsb3JlbSBmYWxsaSBtdW5kaSBzZWEgZXUuIFV0IGV1bSBnbG9yaWF0dXIgc2FkaXBzY2luZywgaXVzIHRlIGV4cGV0ZW5kYSBvbWl0dGFudHVy";
            const string expected = "Ut est etiam invenire maluisset, ea porro debitis indoctum vim, ad eos error invidunt constituto. Eu velit quando fabellas sea. Sea fabellas dignissim at, lorem falli mundi sea eu. Ut eum gloriatur sadipscing, ius te expetenda omittantur";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(input);
            var actual = _Base64Converter.FromBase64Bytes(inputBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_FromBase64Bytes_GivenTest3_ExpectResult3()
        {
            // arrange
            const string input = "bG9jacOzbg==";
            const string expected = "loción";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(input);
            var actual = _Base64Converter.FromBase64Bytes(inputBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected: expected, actual: actual);
        }

        [Test]
        public void When_FromBase64String_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string input = "";
            const string expected = "";

            // act
            var actualBytes = _Base64Converter.FromBase64String(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_GivenTest1_ExpectResult1()
        {
            // arrange
            const string input = "YWJj";
            const string expected = "abc";

            // act
            var actualBytes = _Base64Converter.FromBase64String(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_GivenTest2_ExpectResult2()
        {
            // arrange
            const string input = "VXQgZXN0IGV0aWFtIGludmVuaXJlIG1hbHVpc3NldCwgZWEgcG9ycm8gZGViaXRpcyBpbmRvY3R1bSB2aW0sIGFkIGVvcyBlcnJvciBpbnZpZHVudCBjb25zdGl0dXRvLiBFdSB2ZWxpdCBxdWFuZG8gZmFiZWxsYXMgc2VhLiBTZWEgZmFiZWxsYXMgZGlnbmlzc2ltIGF0LCBsb3JlbSBmYWxsaSBtdW5kaSBzZWEgZXUuIFV0IGV1bSBnbG9yaWF0dXIgc2FkaXBzY2luZywgaXVzIHRlIGV4cGV0ZW5kYSBvbWl0dGFudHVy";
            const string expected = "Ut est etiam invenire maluisset, ea porro debitis indoctum vim, ad eos error invidunt constituto. Eu velit quando fabellas sea. Sea fabellas dignissim at, lorem falli mundi sea eu. Ut eum gloriatur sadipscing, ius te expetenda omittantur";

            // act
            var actualBytes = _Base64Converter.FromBase64String(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_GivenTest3_ExpectResult3()
        {
            // arrange
            const string input = "bG9jacOzbg==";
            const string expected = "loción";

            // act
            var actualBytes = _Base64Converter.FromBase64String(input);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64Bytes_Then_FromBase64Bytes_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string expected = "";

            // act
            var base64Bytes = _Base64Converter.ToBase64Bytes(expected);
            var actual = _Base64Converter.FromBase64Bytes(base64Bytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64Bytes_Then_FromBase64Bytes_GivenTest1_ExpectResult1()
        {
            // arrange
            const string expected = "abc";

            // act
            var base64Bytes = _Base64Converter.ToBase64Bytes(expected);
            var actual = _Base64Converter.FromBase64Bytes(base64Bytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64Bytes_Then_FromBase64Bytes_GivenTest2_ExpectResult2()
        {
            // arrange
            const string expected = "Ut est etiam invenire maluisset, ea porro debitis indoctum vim, ad eos error invidunt constituto. Eu velit quando fabellas sea. Sea fabellas dignissim at, lorem falli mundi sea eu. Ut eum gloriatur sadipscing, ius te expetenda omittantur";

            // act
            var base64Bytes = _Base64Converter.ToBase64Bytes(expected);
            var actual = _Base64Converter.FromBase64Bytes(base64Bytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64Bytes_Then_FromBase64Bytes_GivenTest3_ExpectResult3()
        {
            // arrange
            const string expected = "loción";

            // act
            var base64Bytes = _Base64Converter.ToBase64Bytes(expected);
            var actual = _Base64Converter.FromBase64Bytes(base64Bytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64String_Then_FromBase64String_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string expected = "";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(expected);
            var base64String = _Base64Converter.ToBase64String(inputBytes);
            var actualBytes = _Base64Converter.FromBase64String(base64String);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64String_Then_FromBase64String_GivenTest1_ExpectResult1()
        {
            // arrange
            const string expected = "abc";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(expected);
            var base64String = _Base64Converter.ToBase64String(inputBytes);
            var actualBytes = _Base64Converter.FromBase64String(base64String);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64String_Then_FromBase64String_GivenTest2_ExpectResult2()
        {
            // arrange
            const string expected = "Ut est etiam invenire maluisset, ea porro debitis indoctum vim, ad eos error invidunt constituto. Eu velit quando fabellas sea. Sea fabellas dignissim at, lorem falli mundi sea eu. Ut eum gloriatur sadipscing, ius te expetenda omittantur";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(expected);
            var base64String = _Base64Converter.ToBase64String(inputBytes);
            var actualBytes = _Base64Converter.FromBase64String(base64String);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_ToBase64String_Then_FromBase64String_GivenTest3_ExpectResult3()
        {
            // arrange
            const string expected = "loción";

            // act
            var inputBytes = _UTF8Converter.ConvertToBytes(expected);
            var base64String = _Base64Converter.ToBase64String(inputBytes);
            var actualBytes = _Base64Converter.FromBase64String(base64String);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_Then_ToBase64String_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string expected = "";

            // act
            var plainBytes = _Base64Converter.FromBase64String(expected);
            var actual = _Base64Converter.ToBase64String(plainBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_Then_ToBase64String_GivenTest1_ExpectResult1()
        {
            // arrange
            const string expected = "YWJj";

            // act
            var plainBytes = _Base64Converter.FromBase64String(expected);
            var actual = _Base64Converter.ToBase64String(plainBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_Then_ToBase64String_GivenTest2_ExpectResult2()
        {
            // arrange
            const string expected = "VXQgZXN0IGV0aWFtIGludmVuaXJlIG1hbHVpc3NldCwgZWEgcG9ycm8gZGViaXRpcyBpbmRvY3R1bSB2aW0sIGFkIGVvcyBlcnJvciBpbnZpZHVudCBjb25zdGl0dXRvLiBFdSB2ZWxpdCBxdWFuZG8gZmFiZWxsYXMgc2VhLiBTZWEgZmFiZWxsYXMgZGlnbmlzc2ltIGF0LCBsb3JlbSBmYWxsaSBtdW5kaSBzZWEgZXUuIFV0IGV1bSBnbG9yaWF0dXIgc2FkaXBzY2luZywgaXVzIHRlIGV4cGV0ZW5kYSBvbWl0dGFudHVy";

            // act
            var plainBytes = _Base64Converter.FromBase64String(expected);
            var actual = _Base64Converter.ToBase64String(plainBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64String_Then_ToBase64String_GivenTest3_ExpectResult3()
        {
            // arrange
            const string expected = "bG9jacOzbg==";

            // act
            var plainBytes = _Base64Converter.FromBase64String(expected);
            var actual = _Base64Converter.ToBase64String(plainBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64Bytes_Then_ToBase64Bytes_GivenEmptyString_ExpectEmptyString()
        {
            // arrange
            const string expected = "";

            // act
            var base64Bytes = _UTF8Converter.ConvertToBytes(expected);
            var plainString = _Base64Converter.FromBase64Bytes(base64Bytes);
            var actualBytes = _Base64Converter.ToBase64Bytes(plainString);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64Bytes_Then_ToBase64Bytes_GivenTest1_ExpectResult1()
        {
            // arrange
            const string expected = "YWJj";

            // act
            var base64Bytes = _UTF8Converter.ConvertToBytes(expected);
            var plainString = _Base64Converter.FromBase64Bytes(base64Bytes);
            var actualBytes = _Base64Converter.ToBase64Bytes(plainString);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64Bytes_Then_ToBase64Bytes_GivenTest2_ExpectResult2()
        {
            // arrange
            const string expected = "VXQgZXN0IGV0aWFtIGludmVuaXJlIG1hbHVpc3NldCwgZWEgcG9ycm8gZGViaXRpcyBpbmRvY3R1bSB2aW0sIGFkIGVvcyBlcnJvciBpbnZpZHVudCBjb25zdGl0dXRvLiBFdSB2ZWxpdCBxdWFuZG8gZmFiZWxsYXMgc2VhLiBTZWEgZmFiZWxsYXMgZGlnbmlzc2ltIGF0LCBsb3JlbSBmYWxsaSBtdW5kaSBzZWEgZXUuIFV0IGV1bSBnbG9yaWF0dXIgc2FkaXBzY2luZywgaXVzIHRlIGV4cGV0ZW5kYSBvbWl0dGFudHVy";

            // act
            var base64Bytes = _UTF8Converter.ConvertToBytes(expected);
            var plainString = _Base64Converter.FromBase64Bytes(base64Bytes);
            var actualBytes = _Base64Converter.ToBase64Bytes(plainString);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void When_FromBase64Bytes_Then_ToBase64Bytes_GivenTest3_ExpectResult3()
        {
            // arrange
            const string expected = "bG9jacOzbg==";

            // act
            var base64Bytes = _UTF8Converter.ConvertToBytes(expected);
            var plainString = _Base64Converter.FromBase64Bytes(base64Bytes);
            var actualBytes = _Base64Converter.ToBase64Bytes(plainString);
            var actual = _UTF8Converter.ConvertToString(actualBytes);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}