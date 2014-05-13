namespace Lace.Functions.Json
{
    public interface IJsonFunction
    {
        string ObjectToJson<T>(T obj);
    }
}
