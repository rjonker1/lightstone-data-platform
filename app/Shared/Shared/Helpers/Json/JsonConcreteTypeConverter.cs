using System;
using Newtonsoft.Json;

namespace DataPlatform.Shared.Helpers.Json
{
    public class JsonConcreteTypeConverter<TConcrete> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //assume we can convert to anything for now
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //JObject jObject;
            //JArray jArray;
            //var json = "";
            //if (reader.TokenType == JsonToken.StartArray)
            //{
            //    jArray = JArray.Load(reader);
            //    json = jArray.ToString();
            //}
            //else
            //{
            //    jObject = JObject.Load(reader);
            //    json = jObject.ToString();
            //}
                
            //var type = typeof(TConcrete);
            //var test = JsonConvert.DeserializeObject(json, type);

            return serializer.Deserialize<TConcrete>(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //use the default serialization - it works fine
            serializer.Serialize(writer, value);
        }
    }
}