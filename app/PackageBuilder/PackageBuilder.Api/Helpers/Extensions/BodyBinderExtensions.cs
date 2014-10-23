using System.IO;
using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PackageBuilder.Api.Helpers.Extensions
{
    public static class BodyBinderExtension
    {
        public static T Body<T>(this Request request)
        {
            request.Body.Position = 0;
            string bodyText;
            using (var bodyReader = new StreamReader(request.Body))
            {
                bodyText = bodyReader.ReadToEnd();
            }

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver()
            };

            return JsonConvert.DeserializeObject<T>(bodyText);
        }
    }
}