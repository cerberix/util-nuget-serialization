using Newtonsoft.Json;

namespace Cerberix.Serialization.JsonNet12
{
    public class JsonNetConverter : IJsonConverter, IJsonSerializer, IJsonDeserializer
    {
        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
