using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Api.Domain.Infrastructure.Dto
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
        public Guid SourceId { get; private set; }
        [DataMember]
        public string SearchTerm { get; private set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public IEnumerable<RequestField> RequestFields { get; private set; }
        public ApiRequestDto()
        {

        }

        public ApiRequestDto(Guid userId, Guid contractId, Guid packageId, Guid sourceId, string searchTerm, string username, IEnumerable<RequestField> requestFields)
        {
            UserId = userId;
            ContractId = contractId;
            PackageId = packageId;
            SourceId = sourceId;
            SearchTerm = searchTerm;
            Username = username;
            RequestFields = requestFields;
        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty && !string.IsNullOrEmpty(SearchTerm) &&
                   !string.IsNullOrEmpty(Username);
        }
    }

    [DataContract]
    public class RequestField
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
    }

    public class ApiPropertyRequest
    {
        public string TrackingNumber { get; private set; }
        public int MaxRowsToReturn { get; private set; }
        public string IdNumber { get; private set; }
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }
        public string Username { get; set; }

        public ApiPropertyRequest()
        {

        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty &&
                   !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(TrackingNumber) &&
                   !string.IsNullOrEmpty(IdNumber);
        }

        public ApiPropertyRequest(Guid contractId, Guid sourceId, string searchTerm, string username,
            string trackingNumber, int maxRowsToReturn, string idNumber)
        {
            TrackingNumber = trackingNumber;
            IdNumber = idNumber;
            MaxRowsToReturn = maxRowsToReturn;
            ContractId = contractId;
            SourceId = sourceId;
            SearchTerm = searchTerm;
            Username = username;
        }
    }

    public class ApiBusinessRequest
    {
        public Guid ContractId { get; private set; }
        public Guid SourceId { get; private set; }
        public string SearchTerm { get; private set; }


        public string UserToken { get; private set; }
        public string CompanyName { get; private set; }
        public string CompanyRegNumber { get; private set; }
        public string CompanyVatNumber { get; private set; }
        public string Username { get; set; }

        public ApiBusinessRequest(Guid contractId, Guid sourceId, string searchTerm, string userToken, string companyName, string companyRegNumber, string companyVatNumber, string username)
        {
            Username = username;
            CompanyVatNumber = companyVatNumber;
            CompanyRegNumber = companyRegNumber;
            CompanyName = companyName;
            UserToken = userToken;
            SearchTerm = searchTerm;
            SourceId = sourceId;
            ContractId = contractId;
        }

        public bool IsValid()
        {
            return ContractId != Guid.Empty && SourceId != Guid.Empty &&
                   !string.IsNullOrEmpty(UserToken);
        }


    }
}
