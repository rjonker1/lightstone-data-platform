using System;
using System.Runtime.Serialization;
using Api.Domain.Core.Contracts;

namespace Api.Domain.Infrastructure.Messages
{
    [DataContract]
    public class RequestReportMessage
    {
        public RequestReportMessage(IRequest request, Guid requestId)
        {
            Request = request;
            RequestId = requestId;
        }

        [DataMember] public readonly IRequest Request;
        [DataMember] public readonly Guid RequestId;
    }
}
