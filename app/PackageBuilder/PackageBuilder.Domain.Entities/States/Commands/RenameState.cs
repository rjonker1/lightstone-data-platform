using System;
using PackageBuilder.Core.Commands;
using PackageBuilder.Domain.Entities.Enums.States;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class RenameState : DomainCommand
    {
        public readonly StateName Name;
        public readonly string Alias;
        public RenameState(Guid id, StateName name, string alias) : base(id)
        {
            Name = name;
            Alias = alias;
        }
    }
}