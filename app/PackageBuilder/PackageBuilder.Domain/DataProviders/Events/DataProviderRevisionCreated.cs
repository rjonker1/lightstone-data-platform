using System;
using System.Collections;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class DataProviderRevisionCreated : DomainEvent
    {
		public readonly string Name;
        public readonly Type ResponseType;
        public readonly IEnumerable DataFields;
        public DataProviderRevisionCreated(Guid id, string name, Type responseType, IEnumerable dataFields)
        {
			Id = id;
			Name = name;
            ResponseType = responseType;
            DataFields = dataFields;
        }

    }
}