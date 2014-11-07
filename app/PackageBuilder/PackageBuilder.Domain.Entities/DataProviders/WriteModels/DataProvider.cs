using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.DataProviders.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    [DataContract]
    public class DataProvider : AggregateBase, IDataProvider
    {
        [DataMember]
        public DataProviderName Name { get; internal set; } //todo use enum
        [DataMember]
        public string Description { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public string SourceURL { get; internal set; }
        [DataMember]
        public Type ResponseType { get; internal set; }
        [DataMember]
        public string Owner { get; internal set; }
        [DataMember]
        public DateTime Created { get; internal set; }
        [DataMember]
        public DateTime Edited { get; internal set; }
        [DataMember]
        public IEnumerable<IDataField> DataFields { get; internal set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider()
        {
        }

        public DataProvider(Guid id, DataProviderName name, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            Id = id;
            Name = name;
            DataFields = dataFields;
        }

        public DataProvider(Guid id, DataProviderName name, string description, double costOfSale, string sourceUrl, Type responseType, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name, description, costOfSale, sourceUrl, responseType, owner, createdDate, editedDate, dataFields));
        }

        public void CreateDataProviderRevision(Guid id, DataProviderName name, string description, double costOfSale, string sourceUrl, Type responseType, int version, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
        {
            RaiseEvent(new DataProviderUpdated(id, name, description, costOfSale, sourceUrl, responseType, version, owner, createdDate, editedDate, dataFields));
        }

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            SourceURL = @event.SourceURL;
            ResponseType = @event.ResponseType;
            Owner = @event.Owner;
            Created = @event.CreatedDate;
            Edited = @event.EditedDate;
            DataFields = @event.DataFields;
        }

        private void Apply(DataProviderUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            SourceURL = @event.SourceURL;
            ResponseType = @event.ResponseType;
            Owner = @event.Owner;
            Created = @event.CreatedDate;
            Edited = @event.EditedDate;
            DataFields = @event.DataFields;
        }
    }
}