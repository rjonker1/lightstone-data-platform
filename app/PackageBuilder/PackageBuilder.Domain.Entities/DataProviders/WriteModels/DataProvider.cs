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
        public string Description { get; private set; }
        public double CostOfSale { get; private set; }
        public string SourceURL { get; private set; }
        public Type ResponseType { get; private set; }
        public string State { get; private set; }
        public string Owner { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Edited { get; private set; }
        public IEnumerable<IDataField> DataFields { get; private set; }

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

        public DataProvider(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate) 
            : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate, editedDate, PopulateDataFields(responseType)));
        }

        public void CreateDataProviderRevision(Guid id, string name, string description, double costOfSale, string sourceUrl, Type responseType, string state, string owner, DateTime createdDate, DateTime editedDate, IEnumerable<IDataField> dataFields)
        {
            RaiseEvent(new DataProviderUpdated(id, name, description, costOfSale, sourceUrl, responseType, state, owner, createdDate, editedDate, dataFields));
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