using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lace.Shared.Extensions
{
    public static class JsonExtensions
    {
        public static string ObjectToJson(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string AsJsonString(this object value)
        {
            if (value == null) return string.Empty;

            return JsonConvert.SerializeObject(value, Formatting.Indented,
                new JsonSerializerSettings {ContractResolver = new CamelCasePropertyNamesContractResolver()});

        }
    }
}
