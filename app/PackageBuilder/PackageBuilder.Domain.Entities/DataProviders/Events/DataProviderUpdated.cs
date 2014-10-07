using System;
using System.Collections;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderUpdated : DomainEvent
    {
        public Guid DataProvierId { get; set; }
		public readonly string Name;
        public readonly string Owner;
        public readonly DateTime Created;
        public readonly DateTime Edited;
        public readonly Type ResponseType;
        public readonly IEnumerable DataFields;
        public DataProviderUpdated(Guid id, string name, string owner, DateTime created, DateTime edited, int version, Type responseType, IEnumerable dataFields)
        {
			Id = id;
            DataProvierId = id;
            Version = version;
            Name = name;
            Owner = owner;
            Created = created;
            Edited = edited;
            ResponseType = responseType;
            DataFields = dataFields;
        }
    }
}