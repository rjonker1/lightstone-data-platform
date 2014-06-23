using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
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