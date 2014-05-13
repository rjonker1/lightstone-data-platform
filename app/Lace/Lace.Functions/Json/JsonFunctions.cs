using Newtonsoft.Json;

namespace Lace.Functions.Json
{
    public class JsonFunctions : IJsonFunction
    {
        private static readonly IJsonFunction Function = new JsonFunctions();

        public static IJsonFunction JsonFunction
        {
            get
            {
                return Function;
            }
        }

        public string ObjectToJson<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {

                return string.Empty;
            }

        }
    }
}
