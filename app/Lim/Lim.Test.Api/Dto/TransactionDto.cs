using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Lim.Test.Api.Dto
{
    public class TransactionDto
    {
        public TransactionDto(Guid packageId, Guid userId, string username, Guid contractId, int accountNumber, DateTime date, Guid requestId,
            string report, bool hasResponse)
        {
            PackageId = packageId;
            UserId = userId;
            Username = username;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = date;
            RequestId = requestId;
            Report = !string.IsNullOrEmpty(report) ? JsonConvert.DeserializeObject(report) : new {};
            HasResponse = hasResponse;
        }

        [DataMember]
        public Guid PackageId { get; private set; }

        [DataMember]
        public Guid UserId { get; private set; }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public int AccountNumber { get; private set; }

        [DataMember]
        public DateTime ResponseDate { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public object Report { get; private set; }

        [DataMember]
        public bool HasResponse { get; private set; }
    }
}