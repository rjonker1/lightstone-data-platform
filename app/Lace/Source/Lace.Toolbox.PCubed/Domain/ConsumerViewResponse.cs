using System;
using System.Net;
using System.Runtime.Serialization;

namespace Lace.Toolbox.PCubed.Domain
{
    [DataContract]
    public class ConsumerViewResponse
    {
        public ConsumerViewResponse()
        {

        }

        public ConsumerViewResponse(Guid externalId, Guid ticket, int errorNumber, string errorMessage, HttpStatusCode responseStatusCode,
            string responseStatus, string username, string companyName, string dataFormat, bool compressed, string queryExecutionTime,
            DateTime queryDate, IndividualData individualData)
        {
            ExternalId = externalId;
            Ticket = ticket;
            ErrorNumber = errorNumber;
            ErrorMessage = errorMessage;
            ResponseStatusCode = responseStatusCode;
            ResponseStatus = responseStatus;
            UserName = username;
            CompanyName = companyName;
            DataFormat = dataFormat;
            Compressed = compressed;
            QueryExecutionTime = queryExecutionTime;
            QueryDate = queryDate;
            IndividualData = individualData;
        }

        [DataMember]
        public Guid ExternalId { get; private set; }

        [DataMember]
        public Guid Ticket { get; private set; }

        [DataMember]
        public int ErrorNumber { get; private set; }

        [DataMember]
        public string ErrorMessage { get; private set; }

        [DataMember]
        public HttpStatusCode ResponseStatusCode { get; private set; }

        [DataMember]
        public string ResponseStatus { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public string CompanyName { get; private set; }

        [DataMember]
        public string DataFormat { get; private set; }

        [DataMember]
        public bool Compressed { get; private set; }

        [DataMember]
        public string QueryExecutionTime { get; private set; }

        [DataMember]
        public DateTime QueryDate { get; private set; }

        [DataMember]
        public IndividualData IndividualData { get; private set; }
    }
}