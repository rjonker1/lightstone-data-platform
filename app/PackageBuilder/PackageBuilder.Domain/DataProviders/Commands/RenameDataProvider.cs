using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.DataProviders.Commands
{
    public class RenameDataProvider : IDomainCommand
    {
        public Guid Id { get; private set; }
        public readonly string NewName;

        public RenameDataProvider(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}