using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cerberix.Serialization.DotNet
{
    public class DotNetUTF8ByteConverter : IByteConverter
    {
        public IReadOnlyCollection<byte> ConvertToBytes(string input)
        {
            if (input == null)
            {
                return null;
            }

            var result = UTF8Encoding.UTF8.GetBytes(input).ToArray();
            return result;
        }

        public string ConvertToString(IReadOnlyCollection<byte> input)
        {
            var inputArray = input.ToArray();
            if (inputArray == null)
            {
                return null;
            }

            var result = UTF8Encoding.UTF8.GetString(inputArray);
            return result;
        }
    }
}
