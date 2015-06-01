using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class PackageTransactionDto
    {
        public PackageTransactionDto()
        {

        }

        private PackageTransactionDto(Guid packageId, Guid userId, string username, Guid contractId, int accountNumber, DateTime responseDate,
            Guid requestId, string payload, bool hasResponse)
        {
            PackageId = packageId;
            UserId = userId;
            Username = username;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = responseDate;
            RequestId = requestId;
            //Report = hasResponse ? JsonConvert.DeserializeObject(payload) : new {};
            Report = hasResponse ? payload : "[{}]";
            HasResponse = hasResponse;
        }

        public static PackageTransactionDto Set(Guid packageId, Guid userId, string username, Guid contractId, int accountNumber,
            DateTime responseDate,
            Guid requestId, string payload, bool hasResponse)
        {
            return new PackageTransactionDto(packageId, userId, username, contractId, accountNumber, responseDate, requestId, payload, hasResponse);
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
        public string Report { get; private set; }

        [DataMember]
        public bool HasResponse { get; private set; }
    }
}