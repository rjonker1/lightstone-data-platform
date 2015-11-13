using System;
using Newtonsoft.Json;

namespace EventTracking.Domain.Core
{
    public static class JsonExtensions
    {
        public static string AsJsonString(this object value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
