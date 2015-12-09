using System;
using System.Collections.Generic;

namespace Lim.Dtos
{
    public class DataPlatformContractDto
    {
        public DataPlatformContractDto()
        {

        }

        public DataPlatformContractDto(Guid id, string name, IEnumerable<PackageDto> packages)
        {
            ContractId = id;
            Name = name;
            Packages = packages;
        }

        public Guid ContractId { get; set; }
        public string Name { get; set; }
        public IEnumerable<PackageDto> Packages { get; set; }
    }
}