using System;

namespace Lim.Domain.Dto
{
    public class DataPlatformPackageDto
    {
        public const string Select =
             @"select distinct cp.ContractId, cp.PackageId Id, p.Name from ContractPackage cp join Package p on cp.PackageId = p.Id";
       
        public DataPlatformPackageDto()
        {

        }

        public DataPlatformPackageDto(Guid id, string name, Guid contractId)
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