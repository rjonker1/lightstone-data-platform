using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Events;
using IDataField = PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
        public readonly DataProviderName Name;
		public readonly string Description;
        public readonly double CostPrice;
        public readonly Type ResponseType;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, DataProviderName name, string description, double costPrice, Type responseType, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields)
        {
			Id = id;
			Name = name;
            Description = description;
            CostPrice = costPrice;
            ResponseType = responseType;
            Owner = owner;
            CreatedDate = createdDate;
            DataFields = dataFields;
        }
    }
}