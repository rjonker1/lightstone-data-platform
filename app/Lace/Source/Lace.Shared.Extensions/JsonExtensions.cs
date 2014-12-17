using Newtonsoft.Json;

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
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
