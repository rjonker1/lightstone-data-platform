using System.Collections.Generic;
using Nancy;

namespace Api.Infrastructure.Metadata
{
    public class DefaultRouteMetadata
    {
        public DefaultRouteMetadata(string method, string path, string description)
        {
            Method = method;
            Path = path;
            Description = description;
            ValidStatusCodes = new[] { HttpStatusCode.Accepted, HttpStatusCode.OK, HttpStatusCode.Processing };
            
        }

        public string Path { get; set; }

        public string Method { get; set; }

        public string Description { get; set; }

        public IEnumerable<HttpStatusCode> ValidStatusCodes { get; set; }

    }
}