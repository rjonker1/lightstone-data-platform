using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DomainEvent
    {
        public Guid DataProvierId { get; set; }
		public readonly string Name;
		public readonly string Description;
        public readonly string Owner;
        public readonly DateTime Created;
        public readonly DateTime Edited;
        public readonly Type ResponseType;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderUpdated(Guid id, string name, string description, string owner, DateTime created, DateTime edited, int version, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
            DataProvierId = id;
            Version = version;
            Name = name;
            Description = description;
            Owner = owner;
            Created = created;
            Edited = edited;
            ResponseType = responseType;
            DataFields = dataFields;
        }
    }
}