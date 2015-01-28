using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.CommercialStates
{
    public class CreateCommercialState : DomainCommand
    {

        public string Name;

        public CreateCommercialState(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}