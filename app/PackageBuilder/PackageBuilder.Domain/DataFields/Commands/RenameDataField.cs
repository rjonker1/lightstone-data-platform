using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.DataFields.Commands
{
    public class RenameDataField : IDomainCommand
    {
        public Guid Id { get; private set; }
        public readonly string NewName;

        public RenameDataField(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}