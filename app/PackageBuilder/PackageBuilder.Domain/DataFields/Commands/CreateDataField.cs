using System;
using PackageBuilder.Domain.Helpers.Cqrs.Commands;

namespace PackageBuilder.Domain.DataFields.Commands
{
    public class CreateDataField : IDomainCommand
    {
        public Guid Id { get; private set; }
        public readonly string Name;
        public readonly Type Type;
        public Guid DataProviderId;

        public CreateDataField(Guid id, string name, Type type, Guid dataProviderId)
        {
            Id = id;
            Name = name;
            Type = type;
            DataProviderId = dataProviderId;
        }
    }
}