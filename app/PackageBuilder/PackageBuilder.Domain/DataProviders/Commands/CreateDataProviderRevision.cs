using System;
using System.Collections;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Helpers.Cqrs.Commands;

namespace PackageBuilder.Domain.DataProviders.Commands
{
    public class CreateDataProviderRevision : IDomainCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public readonly string Name;
        public readonly Type DataProviderType;
        public readonly IEnumerable DataFields;

        public CreateDataProviderRevision(Guid id, int version, string name, Type dataProviderType, IEnumerable dataFields)
        {
            Id = id;
            Version = version;
            Name = name;
            DataProviderType = dataProviderType;
            DataFields = dataFields;

        }

    }
    
}
