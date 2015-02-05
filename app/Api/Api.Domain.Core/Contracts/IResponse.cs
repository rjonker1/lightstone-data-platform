using System.Collections.Generic;
using Nancy;

namespace Api.Domain.Core.Contracts
{
    public interface IResponse
    {
        string ContentType { get; set; }
        IDictionary<string, string> Headers { get; set; }
        string ReasonPhrase { get; set; }
        HttpStatusCode StatusCode { get; set; }
        string Response { get; set; }
    }
}