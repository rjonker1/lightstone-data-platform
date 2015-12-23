using System;
using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class IntegrationClientDto
    {
        public IntegrationClientDto()
        {

        }

        private IntegrationClientDto(Guid clientCustomerId, int accountNumber, long configuration, bool isActive)
        {
            ClientCustomerId = clientCustomerId;
            AccountNumber = accountNumber;
            Configuration = configuration;
            IsActive = isActive;
        }

        private IntegrationClientDto(long id, Guid clientCustomerId, int accountNumber, long configuration, bool isActive,
            DateTime? dateModified, string modifiedBy)
        {
            Id = id;
            ClientCustomerId = clientCustomerId;
            AccountNumber = accountNumber;
            Configuration = configuration;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        public static IntegrationClientDto New(Guid clientCustomerId, int accountNumber, long configuration, bool isActive)
        {
            return new IntegrationClientDto(clientCustomerId, accountNumber, configuration, isActive);
        }

        public static IntegrationClientDto Existing(long id, Guid clientCustomerId, int accountNumber, long configuration, bool isActive,
            DateTime? dateModified, string modifiedBy)
        {
            return new IntegrationClientDto(id, clientCustomerId, accountNumber, configuration, isActive, dateModified, modifiedBy);
        }

        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public Guid ClientCustomerId { get; private set; }

        [DataMember]
        public int AccountNumber { get; private set; }

        [DataMember]
        public long Configuration { get; private set; }

        [DataMember]
        public bool IsActive { get; private set; }

        [DataMember]
        public DateTime DateCreated { get; private set; }

        [DataMember]
        public DateTime? DateModified { get; private set; }

        [DataMember]
        public string ModifiedBy { get; private set; }
    }
}