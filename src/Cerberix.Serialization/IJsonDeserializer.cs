namespace Cerberix.Serialization
{
    public interface IJsonDeserializer
    {
        T Deserialize<T>(string value);
    }
}
