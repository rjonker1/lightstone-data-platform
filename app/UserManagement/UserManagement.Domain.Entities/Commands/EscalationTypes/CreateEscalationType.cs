using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.EscalationTypes
{
    public class CreateEscalationType : DomainCommand
    {

        public string Name;

        public CreateEscalationType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}