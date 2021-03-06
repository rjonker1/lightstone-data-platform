﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using PackageBuilder.Core.Attributes;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.Write
{
    [DataContract]
    public class DataProvider : AggregateBase, IDataProvider
    {
        [DataMember]
        public Guid Id
        {
            get { return base.Id; }
            internal set { base.Id = value; }
        }
        [DataMember]
        public DataProviderName Name { get; internal set; } 
        [DataMember]
        public string Description { get; internal set; }
        [DataMember, MapToCurrentValue]
        public decimal CostOfSale { get; internal set; }
        public ISourceConfiguration SourceConfiguration
        {
            get
            {
                return new SourceConfiguration(Name);
            }
        }
        [DataMember]
        public Type ResponseType { get; internal set; }
        [DataMember, MapToCurrentValue]
        public bool FieldLevelCostPriceOverride { get; internal set; }
        [DataMember]
        public string Owner { get; internal set; }
        [DataMember]
        public DateTime CreatedDate { get; internal set; }
        [DataMember]
        public DateTime? EditedDate { get; internal set; }
        [DataMember]
        public IEnumerable<IDataField> RequestFields { get; set; }
        [DataMember]
        public IEnumerable<IDataField> DataFields { get; set; }
        [DataMember]
        public int Version
        {
            get { return base.Version; }
            internal set { base.Version = value; }
        }
        [DataMember]
        public bool RequiresConsent { get; internal set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        //Default constructor for deserialization
        public DataProvider() { }

        public DataProvider(Guid id, DataProviderName name, string description, decimal costOfSale, Type responseType, bool fieldLevelCostPriceOverride, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> dataFields)
            : this(id)
        {
            Name = name;
            Description = description;
            CostOfSale = costOfSale;
            ResponseType = responseType;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            Owner = owner;
            CreatedDate = createdDate;
            EditedDate = editedDate;
            DataFields = dataFields;
        }

        public DataProvider(Guid id, DataProviderName name, string description, decimal costOfSale, Type responseType, string owner, DateTime createdDate, IEnumerable<IDataField> requestFields, IEnumerable<IDataField> dataFields, int version) 
            : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name, description, costOfSale, responseType, owner, createdDate, requestFields, dataFields, version));
        }

        public void CreateDataProviderRevision(Guid id, DataProviderName name, string description, decimal costOfSale, Type responseType, bool fieldLevelCostPriceOverride, bool requiresConsent, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> requestFields, IEnumerable<IDataField> dataFields)
        {
            RaiseEvent(new DataProviderUpdated(id, name, description, costOfSale, responseType, fieldLevelCostPriceOverride, requiresConsent, version, owner, createdDate, editedDate, requestFields, dataFields));
        }

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            ResponseType = @event.ResponseType;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            RequestFields = @event.RequestFields;
            DataFields = @event.DataFields;
        }

        private void Apply(DataProviderUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            ResponseType = @event.ResponseType;
            FieldLevelCostPriceOverride = @event.FieldLevelCostPriceOverride;
            RequiresConsent = @event.RequiresConsent;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;
            RequestFields = @event.RequestFields;
            DataFields = @event.DataFields;
        }

        public override string ToString()
        {
            return "{0} - {1} - {2}".FormatWith(GetType().FullName, Id, Name);
        }
       
        public DataProviderResponseState ResponseState { get; internal set; }
    }
}