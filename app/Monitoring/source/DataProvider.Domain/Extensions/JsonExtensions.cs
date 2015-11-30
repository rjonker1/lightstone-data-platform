﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DataProvider.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string AsJsonString(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value, Formatting.Indented,
                    new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});
            }
            catch
            {
                return string.Empty;
            }
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

        public static dynamic JsonToObject(this string json)
        {
            try
            {
                return string.IsNullOrWhiteSpace(json) || !IsJson(json) ? json : JsonConvert.DeserializeObject(json);
            }
            catch
            {
                return default(dynamic);
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