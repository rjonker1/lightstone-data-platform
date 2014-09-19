using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type ResponseType;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, string name, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
			Name = name;
            ResponseType = responseType;
            DataFields = dataFields;
        }
    }
}