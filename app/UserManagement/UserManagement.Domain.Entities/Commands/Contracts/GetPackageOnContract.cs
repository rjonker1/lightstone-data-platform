using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Contracts
{
    public class GetPackageOnContract : DomainCommand
    {
        public readonly Guid ContractId;

        public GetPackageOnContract(Guid contractId)
        {
            ContractId = contractId;
        }
    }
}
