using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class ApiRequestDto
    {
        public ApiRequestDto()
        {
            RequestId = Guid.NewGuid();
            SystemType = SystemType.Api;
        }

        [DataMember]
        public Guid CustomerClientId { get; private set; }
        [DataMember]
        public Guid UserId { get; private set; }
        [DataMember]
        public string ContactNumber { get; private set; }
        [DataMember]
        public Guid ContractId { get; private set; }
        [DataMember]
        public Guid PackageId { get; private set; }
        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public Guid SourceId { get; private set; }
        [DataMember]
        public string SearchTerm { get; private set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public long ContractVersion { get; private set; }
        [DataMember]
        public SystemType SystemType { get; private set; }
        [DataMember]
        public IEnumerable<RequestFieldDto> RequestFields { get; private set; }
        [DataMember]
        public bool HasConsent { get; private set; }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty && !string.IsNullOrEmpty(SearchTerm) &&
                   !string.IsNullOrEmpty(Username);
        }

        public void SetContractVersion(long version)
        {
            ContractVersion = version;
        }

        public void SetContactNumber(string contactNumber)
        {
            ContactNumber = contactNumber;
        }

        public void SetRequestMetadata(SystemType systemType)
        {
            SystemType = systemType;
        }

        public ApiRequestDto(Guid customerClientId, Guid userId, Guid contractId, Guid packageId, IEnumerable<RequestFieldDto> requestFields, bool hasConsent)
        {
            CustomerClientId = customerClientId;
            UserId = userId;
            ContractId = contractId;
            PackageId = packageId;
            RequestFields = requestFields;
            HasConsent = hasConsent;
        }
    }
}