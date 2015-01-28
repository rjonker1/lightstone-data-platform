using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.ContractDurations
{
    public class CreateContractDuration : DomainCommand
    {


        public string Name;

        public CreateContractDuration(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}