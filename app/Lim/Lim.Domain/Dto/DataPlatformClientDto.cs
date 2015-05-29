using System;
using System.Collections.Generic;

namespace Lim.Domain.Dto
{
    public class DataPlatformClientDto
    {
        public DataPlatformClientDto()
        {
            
        }

        public DataPlatformClientDto(Guid id, string name, string accountNumber, bool isActive, IEnumerable<DataPlatformContractDto> contracts)
        {
            ClientCustomerId = id;
            Name = name;
            AccountNumber = accountNumber;
            Contracts = contracts;
            IsActive = isActive;
        }

        public Guid ClientCustomerId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<DataPlatformContractDto> Contracts { get; set; }
    }

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

    public class PackageDto
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}