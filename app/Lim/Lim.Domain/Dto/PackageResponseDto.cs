using System;
using System.Linq;

namespace Lim.Domain.Dto
{
    public class PackageResponseDto
    {
        public const string SelectStatement = @"select pr.* from PackageResponses pr where pr.PackageId = @PackageId and pr.ContractId = @ContractId";

        public PackageResponseDto()
        {

        }

        public PackageResponseDto(Guid packageId, Guid userId, Guid contractId, string accountNumber, DateTime responseDate, string payload,
            bool hasData, Guid requestId, string username)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = !string.IsNullOrEmpty(accountNumber) ? int.Parse(string.Join("", accountNumber.Where(Char.IsNumber)).TrimStart('0')) : -1;
            ResponseDate = responseDate;
            Payload = payload;
            HasResponse = hasData;
            RequestId = requestId;
            Username = username;
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public int AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
        public string Payload { get; private set; }
        public bool HasResponse { get; private set; }
        public string Username { get; private set; }
    }
}