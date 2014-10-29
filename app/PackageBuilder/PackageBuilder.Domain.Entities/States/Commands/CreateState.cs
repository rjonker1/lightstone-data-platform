using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class CreateState : IDomainCommand
    {
        public Guid Id;
        public readonly string Name;

        public CreateState(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}