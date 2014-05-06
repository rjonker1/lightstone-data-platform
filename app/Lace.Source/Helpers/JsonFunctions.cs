using Newtonsoft.Json;

namespace Lace.Source.Helpers
{
    public static class JsonFunctions
    {
        public static string ObjectToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
