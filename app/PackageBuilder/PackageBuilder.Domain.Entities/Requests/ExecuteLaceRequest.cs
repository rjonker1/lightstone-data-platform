using System;
using System.Collections.Generic;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Requests.RequestTypes;

namespace PackageBuilder.Domain.Entities.Requests
{
    public struct ExecuteLaceRequest
    {
        public ExecuteLaceRequest(Guid userId, string userName, string firstName, Guid requestId, string accountNumber,
            Guid contractId, long contractVersion, SystemType system, IEnumerable<RequestFieldDto> requestFields, double costPrice, double recommendedPrice, bool hasConsent, string contactNumber, IBuildRequest requestBuilder)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            RequestId = requestId;
            AccountNumber = accountNumber;
            ContractId = contractId;
            ContractVersion = contractVersion;
            System = system;
            RequestFields = requestFields;
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
            HasConsent = hasConsent;
            ContactNumber = contactNumber;
            RequestBuilder = requestBuilder;
            User = new User(userId, userName, firstName);
            Contract = new Contract(contractVersion, accountNumber, contractId);
            RequestContext = new RequestContext(requestId, system);
        }

        public readonly Guid UserId;
        public readonly string UserName;
        public readonly string FirstName;
        public readonly Guid RequestId;
        public readonly string AccountNumber;
        public readonly Guid ContractId;
        public readonly long ContractVersion;
        public readonly SystemType System;
        public readonly IEnumerable<RequestFieldDto> RequestFields;
        public readonly double CostPrice;
        public readonly double RecommendedPrice;
        public readonly bool HasConsent;
        public readonly string ContactNumber;
        public readonly IBuildRequest RequestBuilder;
        public readonly User User;
        public readonly Contract Contract;
        public readonly RequestContext RequestContext;
    }
}
