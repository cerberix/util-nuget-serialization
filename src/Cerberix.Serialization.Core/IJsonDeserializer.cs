namespace Cerberix.Serialization.Core
{
    public interface IJsonDeserializer
    {
        T Deserialize<T>(string value);
    }
}
