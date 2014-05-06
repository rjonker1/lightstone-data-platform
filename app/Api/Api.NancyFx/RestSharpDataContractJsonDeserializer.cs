using System.Globalization;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace Api.NancyFx
{
    public class RestSharpDataContractJsonDeserializer : IDeserializer 
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public CultureInfo Culture { get; set; }

        public RestSharpDataContractJsonDeserializer()
        {
            Culture = CultureInfo.InvariantCulture;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            // Deserialize failed when collection was initialized for some reason when using restSharp deserializer on T
            return JsonConvert.DeserializeObject<T>(response.Content); 
        }
    }
}