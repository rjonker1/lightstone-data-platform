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
        public readonly string State;
        public readonly double Cos;
        public readonly DateTime Date;
        public readonly string Owner;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, int version, string name, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
            Version = version;
			Name = name;
            ResponseType = responseType;
            State = null;
            Cos = 0.00;
            Date = new DateTime();
            Owner = null;
            DataFields = dataFields;
        }
    }
}