using System;
namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveContractInformation
    {
        Guid ContractId { get; }
        long ContractVersion { get; }
        string AccountNumber { get; }
    }
}
