using Linear.Contracts;
using Newtonsoft.Json;

namespace Linear
{
    public class JsonEventSerializer : IEventSerializer
    {
        public T Deserialize<T>(string data) where T : class
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
