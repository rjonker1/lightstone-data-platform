using Newtonsoft.Json;

namespace Lace.Shared.Extensions
{
    public static class JsonExtensions
    {
        public static string ObjectToJson(this object value)
        {
            try
            {
                return JsonConvert.SerializeObject(value);
            }
            catch
            {

                return string.Empty;
            }

        }
    }
}
