using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    [DataContract]
    public class DataProvider : AggregateBase, IDataProvider
    {
        [DataMember]
        public string Name { get; internal set; }
        [DataMember]
        public string Description { get; internal set; }
        [DataMember]
        public double CostOfSale { get; internal set; }
        [DataMember]
        public string SourceURL { get; internal set; }
        [DataMember]
        public Type ResponseType { get; internal set; }
        [DataMember]
        public string State { get; internal set; }
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

        public DataProvider(Guid id, string name, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            Id = id;
            Name = name;
            DataFields = dataFields;
        }

        public DataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate) 
            : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate, editedDate, PopulateDataFields(responseType)));
        }

        public void CreateDataProviderRevision(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
        {
            RaiseEvent(new DataProviderUpdated(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate, editedDate, dataFields));
        }

        public DataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl,
            Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate,
            IEnumerable<IDataField> dataFields)
        {
            
        }

        private IEnumerable<IDataField> PopulateDataFields(Type type)
        {
            var fields = type.GetPublicProperties().Select(x => new Tuple<string, Type>(x.Name, x.PropertyType));
            return fields.Select(field => new DataField(field.Item1, field.Item2)).ToList();
        }

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            SourceURL = @event.SourceURL;
            ResponseType = @event.ResponseType;
            State = @event.State;
            Owner = @event.Owner;
            Created = @event.CreatedDate;
            Edited = @event.EditedDate;
            DataFields = PopulateDataFields(@event.ResponseType);
        }

        private void Apply(DataProviderUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Description = @event.Description;
            CostOfSale = @event.CostPrice;
            SourceURL = @event.SourceURL;
            ResponseType = @event.ResponseType;
            State = @event.State;
            Owner = @event.Owner;
            Created = @event.CreatedDate;
            Edited = @event.EditedDate;
            DataFields = @event.DataFields;
        }
    }
}