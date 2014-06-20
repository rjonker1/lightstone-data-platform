using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain
{
    public class ContractPackage : IContractPackage
    {
        public Guid Id { get; set; }
        public DateTime ValidUntil { get; set; }
        public IPackage Package { get; set; }
        public IAction Action { get; set; }
        public IContract Contract { get; set; }
    }
}