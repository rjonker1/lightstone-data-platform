using System;
using System.Runtime.Serialization;
using System.Security.Policy;

namespace Lim.Test.Api.Models.Packages
{
    [DataContract]
    public class Transaction
    {
        public Transaction()
        {
        }

        [DataMember]
        public Guid PackageId { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public Guid ContractId { get; set; }

        [DataMember]
        public int AccountNumber { get; set; }

        [DataMember]
        public DateTime ResponseDate { get; set; }

        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public string Report { get; set; }

        [DataMember]
        public bool HasResponse { get; set; }
    }
}