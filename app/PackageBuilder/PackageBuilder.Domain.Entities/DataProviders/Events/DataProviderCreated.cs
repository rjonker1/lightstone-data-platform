using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
        public readonly Guid DataProviderId;
		public readonly string Name;
		public readonly string Description;
        public readonly Type ResponseType;
        public readonly string State;
        public readonly double CostOfSale;
        public readonly DateTime Created;
        public readonly DateTime Edited;
        public readonly string Owner;
        public readonly string SourceURL;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, Guid dataProviderId, string name, string description, Type responseType, IEnumerable<IDataField> dataFields)
        {
			Id = id;
            DataProviderId = dataProviderId;
			Name = name;
            Description = description;
            ResponseType = responseType;
            State = null;
            CostOfSale = 0.00;
            Created = DateTime.Now;
            Owner = null;
            DataFields = dataFields;
        }
    }
}