using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Core.Helpers.Extensions;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.DataProviders.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.WriteModels
{
    public class DataProvider : AggregateBase, IDataProvider
    {
        public string Name { get; private set; }
        public string State { get; private set; }
        public double CostOfSale { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public string Owner { get; private set; }
        public string SourceURL { get; private set; }
        public IEnumerable<IDataField> DataFields { get; private set; }
        public Type ResponseType { get; private set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider(Guid id, string name, IEnumerable<IDataField> dataFields) 
            : this(id)
        {
            Id = id;
            Name = name;
            DataFields = dataFields;
        }

        public DataProvider(Guid id, string name, string description, Type responseType) 
            : this(id)
        {
            RaiseEvent(new DataProviderCreated(Guid.NewGuid(), id, name, description, responseType, PopulateDataFields(responseType)));
        }

        public void CreateDataProviderRevision(Guid id, string name, string description, string owner, DateTime created, DateTime edited, int version, Type responseType, IEnumerable<IDataField> dataFields)
        {
            RaiseEvent(new DataProviderUpdated(id, name, description, owner, created, edited, version, responseType, dataFields));
        }
        
        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
                RaiseEvent(new DataProviderRenamed(Id, newName));
        }

        private IEnumerable<IDataField> PopulateDataFields(Type type)
        {
            var fields = type.GetPublicProperties().Select(x => new Tuple<string, Type>(x.Name, x.PropertyType));
            return fields.Select(field => new DataField(field.Item1, field.Item2));
        }

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            State = @event.State;
            CostOfSale = @event.CostOfSale;
            Created = @event.Created;
            Owner = @event.Owner;
            DataFields = PopulateDataFields(@event.ResponseType);
        }

        private void Apply(DataProviderRenamed @event)
        {
            Id = @event.Id;
            Name = @event.NewName;
        }

        private void Apply(DataProviderUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            DataFields = @event.DataFields;
        }
    }
}