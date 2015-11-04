using System;

namespace Monitoring.Domain.Identifiers
{
    public class ApiRequestIdentifier
    {
        public ApiRequestIdentifier(UrlIdentifier url, HeaderIdentifier header, string method, string userHostAddress, Guid requestId,
            DateTime requestDate, string jsonRequest, string userName)
        {
            Url = url;
            Header = header;
            Method = method;
            UserHostAddress = userHostAddress;
            RequestId = requestId;
            RequestDate = requestDate;
            JsonRequest = jsonRequest;
            UserName = userName;
        }

        public UrlIdentifier Url { get; private set; }
        public HeaderIdentifier Header { get; private set; }
        public string Method { get; private set; }
        public string UserHostAddress { get; private set; }
        public string UserName { get; private set; }
        public Guid RequestId { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string JsonRequest { get; private set; }
    }

    public class UrlIdentifier
    {
        public UrlIdentifier(string basePath, string hostName, bool isSecure, string path, int? port, string query, string scheme, string siteBase)
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

        public string BasePath { get; private set; }
        public string HostName { get; private set; }
        public bool IsSecure { get; private set; }
        public string Path { get; private set; }
        public int? Port { get; private set; }
        public string Query { get; private set; }
        public string Scheme { get; private set; }
        public string SiteBase { get; private set; }
    }

    public class HeaderIdentifier
    {
        public HeaderIdentifier(string authorization, string host, string userAgent, string contentType)
        {
            Authorization = authorization;
            Host = host;
            UserAgent = userAgent;
            ContentType = contentType;
        }

        public string Authorization { get; private set; }
        public string Host { get; private set; }
        public string UserAgent { get; private set; }
        public string ContentType { get; private set; }
    }
}