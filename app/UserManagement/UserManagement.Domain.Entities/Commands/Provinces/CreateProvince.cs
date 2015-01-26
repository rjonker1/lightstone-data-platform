using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Provinces
{
    public class CreateProvince : DomainCommand
    {
         
        public string Name;

        public CreateProvince(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}