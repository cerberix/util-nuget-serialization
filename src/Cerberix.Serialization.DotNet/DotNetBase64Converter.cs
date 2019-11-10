using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerberix.Serialization.DotNet
{
    public class DotNetBase64Converter : IBase64Converter
    {
        private readonly IByteConverter ByteConverter;

        public DotNetBase64Converter(IByteConverter byteConverter)
        {
            ByteConverter = byteConverter;
        }

        public IReadOnlyCollection<byte> FromBase64String(string input)
        {
            if (input == null)
            {
                return null;
            }

            var result = Convert.FromBase64String(input).ToArray();
            return result;
        }

        public string FromBase64Bytes(IReadOnlyCollection<byte> input)
        {
            if (input == null)
            {
                return null;
            }

            var inputString = ByteConverter.ConvertToString(input);
            var resultBytes = FromBase64String(inputString);
            var result = ByteConverter.ConvertToString(resultBytes);
            return result;
        }

        public IReadOnlyCollection<byte> ToBase64Bytes(string input)
        {
            if (input == null)
            {
                return null;
            }

            var inputBytes = ByteConverter.ConvertToBytes(input).ToArray();
            var resultString = ToBase64String(inputBytes);
            var result = ByteConverter.ConvertToBytes(resultString).ToArray();
            return result;
        }

        public string ToBase64String(IReadOnlyCollection<byte> input)
        {
            if (input == null)
            {
                return null;
            }

            var ensured = input.ToArray();
            var result = Convert.ToBase64String(ensured);
            return result;
        }
    }
}
