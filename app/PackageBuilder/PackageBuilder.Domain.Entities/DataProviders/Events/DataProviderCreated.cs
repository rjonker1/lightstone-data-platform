﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Events
{
    public class DataProviderCreated : DomainEvent
    {
		public readonly string Name;
		public readonly string Description;
        public readonly double CostPrice;
        public readonly string SourceURL;
        public readonly Type ResponseType;
        public readonly string State;
        public readonly string Owner;
        public readonly DateTime CreatedDate;
        public readonly DateTime EditedDate;
        public readonly IEnumerable<IDataField> DataFields;
        public DataProviderCreated(Guid id, string name, string description, double costPrice, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
        {
			Id = id;
			Name = name;
            Description = description;
            CostPrice = costPrice;
            SourceURL = sourceUrl;
            ResponseType = responseType;
            State = state;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataFields = dataFields;
        }
    }
}