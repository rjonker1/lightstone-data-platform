using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using PackageBuilder.Core.Attributes;
using PackageBuilder.Domain.Entities.DataProviders.Events;
using IDataField = PackageBuilder.Domain.Entities.DataFields.WriteModels.IDataField;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
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
        [DataMember, MapCurrentValue]
        public double CostOfSale { get; internal set; }

        public SourceConfiguration SourceConfiguration
        {
            get
            {
                return new SourceConfiguration(Name);
            }
        }

        [DataMember]
        public Type ResponseType { get; internal set; }
        [DataMember, MapCurrentValue]
        public bool FieldLevelCostPriceOverride { get; internal set; }
        [DataMember]
        public string Owner { get; internal set; }
        [DataMember]
        public DateTime CreatedDate { get; internal set; }
        [DataMember]
        public DateTime? EditedDate { get; internal set; }
        [DataMember]
        public IEnumerable<IDataField> DataFields { get; internal set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider()
        {
        }

        public DataProvider(Guid id, DataProviderName name, double costOfSale, bool fieldLevelCostPriceOverride, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            Id = id;
            Name = name;
            FieldLevelCostPriceOverride = fieldLevelCostPriceOverride;
            CostOfSale = costOfSale;
            DataFields = dataFields;
        }

        public DataProvider(Guid id, DataProviderName name, string description, double costOfSale, Type responseType, string owner, DateTime createdDate, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            //SetDataProviderId(id, dataFields);
            RaiseEvent(new DataProviderCreated(id, name, description, costOfSale, responseType, owner, createdDate, dataFields));
        }

        public void CreateDataProviderRevision(Guid id, DataProviderName name, string description, double costOfSale, Type responseType, bool fieldLevelCostPriceOverride, int version, string owner, DateTime createdDate, DateTime? editedDate, IEnumerable<IDataField> dataFields)
        {
            //SetDataProviderId(id, dataFields);
            RaiseEvent(new DataProviderUpdated(id, name, description, costOfSale, responseType, fieldLevelCostPriceOverride, version, owner, createdDate, editedDate, dataFields));
        }

        //private void SetDataProviderId(Guid id, IEnumerable<IDataField> dataFields)
        //{
        //    if (dataFields == null) return;
        //    foreach (var dataField in dataFields.Traverse(x => x.DataFields))
        //        dataField.SetDataProviderId(id);
        //}

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            ResponseType = @event.ResponseType;
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
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
            Owner = @event.Owner;
            CreatedDate = @event.CreatedDate;
            EditedDate = @event.EditedDate;
            DataFields = @event.DataFields;
        }
    }
}