using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
        public readonly DataProviderName Name;
		public readonly string Description;
        public readonly double CostPrice;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime EditedDate;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, DataProviderName name, string description, double costPrice, string sourceUrl, Type responseType, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
        {
			Id = id;
			Name = name;
            Description = description;
            CostPrice = costPrice;
            SourceURL = sourceUrl;
            ResponseType = responseType;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataFields = dataFields;
        }
    }
}