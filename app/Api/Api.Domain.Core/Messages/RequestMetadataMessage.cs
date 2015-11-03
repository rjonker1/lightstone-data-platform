using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Dto;
using DataPlatform.Shared.Helpers;

namespace Api.Domain.Core.Messages
{
    [DataContract]
    public class RequestMetadataMessage
    {
        public RequestMetadataMessage()
        {
            Header = new RequestHeaderMetadataDto();
            Url = new RequestUrlMetadataDto();
        }

        public RequestMetadataMessage(RequestHeaderMetadataDto header, RequestUrlMetadataDto url, Guid requestId, string user)
        {
            Header = header;
            Url = url;
            RequestId = requestId;
            User = user;
            Date = SystemTime.Now();
        }

        [DataMember] public readonly RequestHeaderMetadataDto Header;
        [DataMember] public readonly RequestUrlMetadataDto Url;
        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DateTime Date;
        [DataMember] public readonly string User;
    }
}
