using System.Collections.Generic;

namespace Cerberix.Serialization.Core
{
    public interface IByteConverter
    {
        string ConvertToString(IReadOnlyCollection<byte> input);
        IReadOnlyCollection<byte> ConvertToBytes(string input);
    }
}
