using Newtonsoft.Json;

namespace Lim.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static T JsonToObject<T>(this string json) where T : class
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) || !IsJson(json) ? null : JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }

        public static string ObjectToJson(this object value)
        {
            if (value == null) return string.Empty;

            try
            {
                return JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch
            {
                return "{}";
            }

        }

        private static bool IsJson(string json)
        {
            json = json.Trim();
            return json.StartsWith("{") && json.EndsWith("}")
                   || json.StartsWith("[") && json.EndsWith("]");
        }
    }
}
