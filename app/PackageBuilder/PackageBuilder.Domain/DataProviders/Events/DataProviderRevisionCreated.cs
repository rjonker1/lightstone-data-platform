using System;
using System.Collections;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.DataProviders.Events
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