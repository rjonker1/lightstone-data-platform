using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class ApiRequestDto
    {
        [DataMember]
        public Guid UserId { get; private set; }
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
        public IEnumerable<RequestFieldDto> RequestFields { get; private set; }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty && !string.IsNullOrEmpty(SearchTerm) &&
                   !string.IsNullOrEmpty(Username);
        }
    }
}