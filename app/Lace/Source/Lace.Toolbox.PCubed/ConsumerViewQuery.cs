using System;
using RestSharp;

namespace Lace.Toolbox.PCubed
{
    public class ConsumerViewQuery
    {
        private const string QueryPath = "{id}/{phone}/{email}/-/{format}";
        private ResponseFormat _format = ResponseFormat.Json;

        private ConsumerViewQuery()
            : this(string.Empty, Guid.Empty)
        {
        }

        public ConsumerViewQuery(string idNumber)
            : this(idNumber, Guid.Empty)
        {
            IdNumber = idNumber;
        }

        public ConsumerViewQuery(string idNumber, Guid associationId)
        {
            IdNumber = idNumber;
            AssociationId = associationId;
        }

        public ConsumerViewQuery(string idNumber, string phoneNumber, string emailAddress):
            this(idNumber)
        {
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public string IdNumber { get; private set; }
        public Guid AssociationId { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }

        public enum ResponseFormat
        {
            Json,
            Xml
        }

        public IRestRequest CreateRequest(ResponseFormat format)
        {
            _format = format;
            return CreateRequest();
        }

        public IRestRequest CreateRequest()
        {
            var request = new RestRequest(QueryPath);
            request.AddUrlSegment("id", string.IsNullOrEmpty(IdNumber) ? "-" : IdNumber.Trim());
            request.AddUrlSegment("phone", string.IsNullOrEmpty(PhoneNumber) ? "-" : PhoneNumber.Trim());
            request.AddUrlSegment("email", string.IsNullOrEmpty(EmailAddress) ? "-" : EmailAddress.Trim());
            request.AddUrlSegment("format", _format.ToString().ToLower());

            return request;
        }
    }

}
