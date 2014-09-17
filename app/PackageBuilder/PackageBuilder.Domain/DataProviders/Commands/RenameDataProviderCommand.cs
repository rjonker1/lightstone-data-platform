using System;
using PackageBuilder.Domain.Helpers.Cqrs.CommandHandling;

namespace PackageBuilder.Domain.DataProviders.Commands
{
    public class RenameDataProviderCommand : Command
    {
        public readonly string NewName;

        public RenameDataProviderCommand(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}