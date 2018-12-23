namespace Cerberix.Serialization.Core
{
    public interface IJsonConverter
    {
        T Deserialize<T>(string value);
        string Serialize(object value);
    }
}
