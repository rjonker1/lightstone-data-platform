using Api.Domain.Core.Contracts;
using Nancy;

namespace Api.Domain.Core.Dto
{
    public class RequestDto : IRequest
    {

        public string UserHostAddress { get; set; }

        public string Method { get; set; }

        public Url Url { get; set; }

        public string Path { get; set; }

        public dynamic Query { get; set; }

        public dynamic Form { get; set; }

        public RequestHeaders Headers { get; set; }
    }
}