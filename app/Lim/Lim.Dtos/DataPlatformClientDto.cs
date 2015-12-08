using System;
using System.Collections.Generic;

namespace Lim.Dtos
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
}