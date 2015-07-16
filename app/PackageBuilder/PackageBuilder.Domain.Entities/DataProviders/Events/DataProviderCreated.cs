using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Events;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
        public readonly DataProviderName Name;
		public readonly string Description;
        public readonly decimal CostPrice;
        public readonly Type ResponseType;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly IEnumerable<IDataField> RequestFields;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, DataProviderName name, string description, decimal costPrice, Type responseType, string owner, DateTime createdDate, IEnumerable<IDataField> requestFields, IEnumerable<IDataField> dataFields, int version)
        {
			Id = id;
			Name = name;
            Description = description;
            CostPrice = costPrice;
            ResponseType = responseType;
            Owner = owner;
            CreatedDate = createdDate;
            RequestFields = requestFields;
            DataFields = dataFields;
            Version = version;
        }
    }
}