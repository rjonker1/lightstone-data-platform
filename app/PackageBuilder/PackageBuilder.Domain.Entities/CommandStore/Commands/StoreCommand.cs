using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.CommandStore.Commands
{
    public class StoreCommand : DomainCommand
    {
        public readonly Type Type;
        public readonly string TypeName;
        public readonly IDomainCommand Command;

        public StoreCommand(Guid id, IDomainCommand command) : base(id)
        {
            Type = command.GetType();
            TypeName = command.GetType().Name;
            Command = command;
        }
    }
}