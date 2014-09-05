using System;

namespace PackageBuilder.Domain.Commands
{
    public abstract class Command
    {
        public Guid Id { get; set; }
        public void CreateAggregateRootId()
        {
            if (Id != Guid.Empty)
                throw new ApplicationException("AggregateRootId cannot be overwritten.");
            Id = Guid.NewGuid();
        }
    }

    public class CreateDataProviderCommand : Command
    {
        public readonly string Name;

        public CreateDataProviderCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class RenameDataProviderCommand : Command
    {
        public readonly string NewName;
        public readonly int OriginalVersion;

        public RenameDataProviderCommand(Guid id, string newName, int originalVersion)
        {
            Id = id;
            NewName = newName;
            OriginalVersion = originalVersion;
        }
    }
}