using System;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateDataProvider : IDomainCommand
    {
        public Guid Id { get; private set; }
        public readonly string Name;
        public readonly string Description;
        public readonly Type DataProviderType;

        public CreateDataProvider(Guid id, string name, string description, Type dataProviderType)
        {
            Id = id;
            Name = name;
            Description = description;
            DataProviderType = dataProviderType;
        }
    }
}