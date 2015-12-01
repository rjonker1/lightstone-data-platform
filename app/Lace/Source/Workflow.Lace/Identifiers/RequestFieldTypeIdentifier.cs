using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Castle.Core.Internal;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Extensions;

namespace Workflow.Lace.Identifiers
{
    [DataContract]
    public sealed class RequestFieldTypeIdentifier
    {
        public RequestFieldTypeIdentifier()
        {

        }

        public static List<RequestFieldTypeIdentifier> GetRequestTypes(ICollection<IPointToLaceRequest> request)
        {
            var requestFields = new List<RequestFieldTypeIdentifier>();
            request.First().Package.DataProviders.ForEach(f => f.Request.ForEach(r => requestFields.Add(new RequestFieldTypeIdentifier(r.AsJsonString()))));
            return requestFields;
        }

        public RequestFieldTypeIdentifier(string payload)
        {
            Payload = payload;
        }

        [DataMember]
        public string Payload { get; private set; }
    }
}