using System.Collections.Generic;

namespace Cerberix.Serialization
{
    public interface IBase64Converter
    {
        string FromBase64Bytes(IReadOnlyCollection<byte> input);
        IReadOnlyCollection<byte> FromBase64String(string input);

        IReadOnlyCollection<byte> ToBase64Bytes(string input);
        string ToBase64String(IReadOnlyCollection<byte> input);
    }
}
