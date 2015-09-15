using Api.Domain.Core.Contracts;
using Nancy;

namespace Api.Domain.Core.Dto
{
    public class ResponseDto : IResponse
    {
        public string ContentType { get; set; }

        public System.Collections.Generic.IDictionary<string, string> Headers { get; set; }

        public string ReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }
    }
}