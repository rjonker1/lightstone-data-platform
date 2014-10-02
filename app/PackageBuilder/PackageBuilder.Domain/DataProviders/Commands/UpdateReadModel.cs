using System;
using PackageBuilder.Core.Helpers.Cqrs.Commands;

namespace PackageBuilder.Domain.DataProviders.Commands
{
    public class UpdateReadModel : IDomainCommand
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Version { get; private set; }

        public UpdateReadModel(Guid id, string name, int version)
        {
            Id = id;
            Name = name;
            Version = version;
        }

    }
}
