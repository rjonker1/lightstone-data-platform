using System;
using Lim.Domain.Repository;

namespace Lim.Domain.Models
{
    
    public class PackageResponse
    {
        private const string InsertStatement =
            @"insert into PackageResponses ([PackageId],[UserId],[ContractId],[AccountNumber],[ResponseDate],[RequestId],[Payload],[HasResponse]) values (@PackageId,@UserId,@ContractId,@AccountNumber,@ResponseDate,@RequestId,@Payload,@HasResponse)";

        public PackageResponse()
        {
            
        }

        public PackageResponse(Guid packageId, Guid userId, Guid contractId, string accountNumber, DateTime responseDate, string payload, bool hasData)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = responseDate;
            Payload = payload;
            HasResponse = hasData;
        }

        public void Insert(ILimRepository repository)
        {
            var parameters = new
            {
                @PackageId = PackageId,
                @UserId = UserId,
                @ContractId = ContractId,
                @AccountNumber =  AccountNumber,
                @ResponseDate = ResponseDate,
                @RequestId = RequestId,
                @Payload = Payload,
                @HasResponse = HasResponse
            };
            repository.Add(InsertStatement, parameters);
        }
        
        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
        public string Payload { get; private set; }
        public bool HasResponse { get; private set; }
    }
}
