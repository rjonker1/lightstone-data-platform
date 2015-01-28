using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.CreateSources
{
    public class CreateCreateSource : DomainCommand
    {

        public string Name;

        public CreateCreateSource(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}