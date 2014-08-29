using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;

namespace PackageBuilder.Domain.Entities
{
    public class ContractPackage : IContractPackage
    {
        public ContractPackage(Guid id, IPackage package, IContract contract, DateTime validUntil)
        {
            Id = id;
            Package = package;
            Contract = contract;
            ValidUntil = validUntil;
        }

        public Guid Id { get; private set; }
        public IPackage Package { get; set; }
        public IContract Contract { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}