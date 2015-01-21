using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.UserTypes
{
    public class CreateUserType : DomainCommand
    {
        public string Name;

        public CreateUserType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}