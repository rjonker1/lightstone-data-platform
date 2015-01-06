using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Monitoring.Projection.UI.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string AsJsonString(this object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented,
                new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }
    }
}