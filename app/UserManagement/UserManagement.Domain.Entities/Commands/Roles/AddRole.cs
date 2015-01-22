using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Roles
{
    public class AddRole : DomainCommand
    {
         public string Name;

        public AddRole(Guid _id, string val)
        {
            Id = _id;
            Name = val;
        }
    }
}