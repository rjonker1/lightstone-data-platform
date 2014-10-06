using System;
using System.Collections;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderRevisionCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type ResponseType;
        public readonly IEnumerable DataFields;
        public DataProviderRevisionCreated(Guid id, int version, string name, Type responseType, IEnumerable dataFields)
        {
			Id = id;
            Version = version;
			Name = name;
            ResponseType = responseType;
            DataFields = dataFields;
        }
    }
}