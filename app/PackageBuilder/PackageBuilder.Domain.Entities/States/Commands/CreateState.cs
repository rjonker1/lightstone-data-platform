using System;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Enums;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class CreateState : IDomainCommand
    {
        public Guid Id;
        public readonly StateName Name;
        public readonly string Alias;

        public CreateState(Guid id, StateName name)
        {
            Id = id;
            Name = name;
            Alias = name.ToString();
        }
    }
}