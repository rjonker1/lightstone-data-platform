﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace DataPlatform.Shared.Dtos
{
    [DataContract]
    public class ApiCommitRequestDto
    {
        public ApiCommitRequestDto()
        {
            UserState = UserState != ApiCommitRequestUserState.Cancelled ? UserState : ApiCommitRequestUserState.Cancelled;
            SystemType = SystemType.Api;
        }

        public void AddStateForRequest(Guid requestId, ApiCommitRequestUserState userState)
        {
            RequestId = requestId;
            UserState = userState;
        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && RequestId != Guid.Empty;
        }

        public void SetContractVersion(long version)
        {
            ContractVersion = version;
        }

        public void SetRequestMetadata(SystemType systemType)
        {
            SystemType = systemType;
        }

        public void SetContactNumber(string contactNumber)
        {
            ContactNumber = contactNumber;
        }

        [DataMember]
        public Guid CustomerClientId { get; private set; }

        [DataMember]
        public Guid UserId { get; private set; }

        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public Guid PackageId { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string ContactNumber { get; set; }
       
        [DataMember]
        public long ContractVersion { get; private set; }

        [DataMember]
        public SystemType SystemType { get; private set; }

        [DataMember]
        public IEnumerable<RequestFieldDto> RequestFields { get; private set; }

        [DataMember]
        public bool HasConsent { get; private set; }

        [DataMember]
        public ApiCommitRequestUserState UserState { get; private set; }
    }
}