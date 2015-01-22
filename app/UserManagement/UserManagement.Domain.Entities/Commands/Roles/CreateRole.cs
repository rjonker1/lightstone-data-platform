using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Roles
{
    public class CreateRole : DomainCommand
    {

        public string Name;

        public CreateRole(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}