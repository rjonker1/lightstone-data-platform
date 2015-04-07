using System;
namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveContract
    {
        Guid ContractId { get; }
        long ContractVersion { get; }
        string AccountNumber { get; }
    }
}
