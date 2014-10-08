using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Commands;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class UpdateDataProvider : IDomainCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public readonly string Name;
        public readonly string Owner;
        public readonly Type DataProviderType;
        public readonly IEnumerable<IDataField> DataFields;

        public UpdateDataProvider(Guid id, string name, string owner, DateTime created, DateTime edited, int version, Type dataProviderType, IEnumerable<IDataField> dataFields)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Created = created;
            Edited = edited;
            Version = version;
            DataProviderType = dataProviderType;
            DataFields = dataFields;
        }
    }
}
