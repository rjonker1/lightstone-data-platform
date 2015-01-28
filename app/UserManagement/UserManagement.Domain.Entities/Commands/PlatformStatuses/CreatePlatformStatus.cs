using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.PlatformStatuses
{
    public class CreatePlatformStatus : DomainCommand
    {

        public string Name;

        public CreatePlatformStatus(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}