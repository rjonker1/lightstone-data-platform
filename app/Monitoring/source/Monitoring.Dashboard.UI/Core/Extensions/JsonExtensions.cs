using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Monitoring.Dashboard.UI.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string AsJsonString(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented,
                new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        public static string ObjectToJson(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch
            {
                return string.Empty;
            }
        }

        public static dynamic JsonToObject(this string json)
        {
            return JsonConvert.DeserializeObject(json);
        }
    }
}