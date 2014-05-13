using Nancy;

namespace Api
{
    public interface IRequest
    {
        string UserHostAddress { get; set; }
        string Method { get; set; }
        Url Url { get; set; }
        string Path { get; set; }
        dynamic Query { get; set; }
        dynamic Form { get; set; }
        RequestHeaders Headers { get; set; }
    }
}