using System;
using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Core.Events;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

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
        public readonly IEnumerable<IAmRequestField> RequestFields;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, DataProviderName name, string description, double costPrice, Type responseType, string owner, DateTime createdDate, IEnumerable<IAmRequestField> requestFields, IEnumerable<IDataField> dataFields)
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
        }
    }
}