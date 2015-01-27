using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.ContractTypes
{
    public class CreateContractType : DomainCommand
    {

        public string Name;

        public CreateContractType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}