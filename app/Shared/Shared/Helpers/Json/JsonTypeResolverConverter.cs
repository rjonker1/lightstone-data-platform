using System;
using DataPlatform.Shared.Helpers.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataPlatform.Shared.Helpers.Json
{
    public class JsonTypeResolverConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //assume we can convert to anything for now
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DeserializeObjectByType(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //use the default serialization - it works fine
            serializer.Serialize(writer, value);
        }

        private object DeserializeObjectByType(JsonReader reader)
        {
            var jObject = JObject.Load(reader);
            var json = jObject.ToString();
            var dObject = (dynamic)jObject;
            var type = Type.GetType(dObject.Type.ToString());
            var typeName = dObject.TypeName.ToString();
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (JsonException exception)
            {
                this.Error(() => string.Format("Could not deserialize command by type: {0} attempting to deserialize by type name {1}", type + "", typeName), exception);
                return DeserializeObjectByTypeName(json, type + "", typeName);
            }
        }

        private object DeserializeObjectByTypeName(string json, string type, string typeName)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, TypeHelper.GetTypeByName(type)[0]);
            }
            catch (JsonException exception)
            {
                this.Error(() => "Could not deserialize command by type: {0} or type name {1}".FormatWith(type, typeName), exception);
                return null;
            }
        }
    }
}