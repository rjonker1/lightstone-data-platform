using System;

namespace Lim.Domain.Models
{
    public class Package
    {
        public const string Select =
             @"select distinct cp.ContractId, cp.PackageId, p.Name from ContractPackage cp join Package p on cp.PackageId = p.Id";
            //@"select distinct cast(cast(0 as binary) as uniqueidentifier) ContractId, cp.PackageId Id, p.Name from ContractPackage cp join Package p on cp.PackageId = p.Id";
       
        public Package()
        {

        }

        public Package(Guid id, string name, Guid contractId)
        {
            Id = id;
            Name = name;
            ContractId = contractId;
        }

        public Guid Id { get; private set; }
        public Guid ContractId { get; private set; }
        public string Name { get; private set; }
    }
}