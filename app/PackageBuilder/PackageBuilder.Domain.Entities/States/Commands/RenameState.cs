using System;
using PackageBuilder.Domain.Entities.Enums;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class RenameState
    {
        public Guid Id;
        public readonly StateName Name;
        public readonly string Alias;
        public RenameState(Guid id, StateName name, string alias)
        {
            Id = id;
            Name = name;
            Alias = alias;
        }
    }
}