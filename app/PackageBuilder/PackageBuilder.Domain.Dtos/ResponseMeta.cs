using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    [DataContract]
    public class ResponseMeta : IProvideResponseDataProvider
    {
        public ResponseMeta(Guid requestId, DataProviderResponseState responseState)
        {
            RequestId = requestId;
            ResponseState = responseState;
            ResponseStateMessage = ResponseState.Description();
        }

        [DataMember] public readonly Guid RequestId;
        [DataMember] public readonly DataProviderResponseState ResponseState;
        [DataMember] public readonly string ResponseStateMessage;
    }
}