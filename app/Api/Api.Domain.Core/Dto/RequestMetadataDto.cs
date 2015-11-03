using System.Runtime.Serialization;

namespace Api.Domain.Core.Dto
{
    [DataContract]
    public class RequestHeaderMetadataDto
    {
        public RequestHeaderMetadataDto()
        {
        }

        public RequestHeaderMetadataDto(string authorization, string host, string userAgent, string contentType)
        {
            Authorization = authorization;
            Host = host;
            UserAgent = userAgent;
            ContentType = contentType;
        }

        [DataMember] public readonly string Authorization;
        [DataMember] public readonly string ContentType;
        [DataMember] public readonly string Host;
        [DataMember] public readonly string UserAgent;
    }

    [DataContract]
    public class RequestUrlMetadataDto
    {
        public RequestUrlMetadataDto()
        {
            
        }
        public RequestUrlMetadataDto(string basePath, string hostName, bool isSecure, string path, int? port, string query, string scheme, string siteBase)
        {
            BasePath = basePath;
            HostName = hostName;
            IsSecure = isSecure;
            Path = path;
            Port = port;
            Query = query;
            Scheme = scheme;
            SiteBase = siteBase;
        }

        [DataMember] public readonly string BasePath;
        [DataMember] public readonly string HostName;
        [DataMember] public readonly bool IsSecure;
        [DataMember] public readonly string Path;
        [DataMember] public readonly int? Port;
        [DataMember] public readonly string Query;
        [DataMember] public readonly string Scheme;
        [DataMember] public readonly string SiteBase;
    }
}
