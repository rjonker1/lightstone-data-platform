using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Dtos
{
    public class IntegrationClientDto
    {
        public IntegrationClientDto(Guid id, string name, string accountNumber, bool isActive, IEnumerable<IntegrationContractDto> contracts)
        {
            ClientCustomerId = id;
            Name = name;
            AccountNumber = accountNumber;
            Contracts = contracts;
            IsActive = isActive;
        }

        public Guid ClientCustomerId { get; private set; }
        public string Name { get; private set; }
        public string AccountNumber { get; private set; }
        public bool IsActive { get; private set; }
        public IEnumerable<IntegrationContractDto> Contracts { get; private set; }
    }
}