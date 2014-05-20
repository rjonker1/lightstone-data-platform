using System;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class ContractPackage : IContractPackage
    {
        public DateTime ValidUntil { get; set; }
        public IPackage Package { get; set; }
        public IAction Action { get; set; }
        public IContract Contract { get; set; }
    }
}