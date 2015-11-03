using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Dto;
using DataPlatform.Shared.Helpers;

namespace Api.Domain.Core.Messages
{
    internal class RequestMetadataMessage
    {
        public RequestMetadataMessage()
        {
            Header = new RequestHeaderMetadataDto();
        }

        public RequestMetadataMessage(RequestHeaderMetadataDto header, RequestUrlMetadataDto url, Guid requestId)
        {
            Header = header;
            Url = url;
            RequestId = requestId;
            Date = SystemTime.Now();
        }

        [DataMember] public readonly RequestHeaderMetadataDto Header;
        [DataMember] public readonly RequestUrlMetadataDto Url;
        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DateTime Date;
    }
}
