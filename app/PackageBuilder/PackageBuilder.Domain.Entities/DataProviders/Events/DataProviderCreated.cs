using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
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
        public DataProviderCreated(Guid id, string name, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
			Name = name;
            ResponseType = responseType;
            State = null;
            Cos = 0.00;

            Date = DateTime.Now;
            Owner = null;
            DataFields = dataFields;
        }
    }
}