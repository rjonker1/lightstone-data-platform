using System;
using System.Collections.Generic;
namespace UserManagement.Domain.Dtos
{
    public class IntegrationContractDto
    {
        public IntegrationContractDto(Guid id, string name, IEnumerable<PackageDto> packages)
        {
            ContractId = id;
            Name = name;
            Packages = packages;
        }

        public Guid ContractId { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<PackageDto> Packages { get; private set; }
    }
}