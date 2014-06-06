using System;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace EventTracking.Domain.Read.Core
{
    public static class JsonExtensions
    {
        public static T ParseJson<T>(this ResolvedEvent data)
        {
            var value = Encoding.UTF8.GetString(data.Event.Data);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static T ParseJson<T>(this RecordedEvent data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var value = Encoding.UTF8.GetString(data.Data);

            return JsonConvert.DeserializeObject<T>(value);
        }


        public static string AsJsonString(this object value)
        {
            if (value == null) throw new ArgumentNullException("value");

            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}
