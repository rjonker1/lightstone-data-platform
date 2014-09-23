using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Common.Helpers.Extensions;
using PackageBuilder.Domain.DataFields.WriteModels;
using PackageBuilder.Domain.DataProviders.Events;

namespace PackageBuilder.Domain.DataProviders.WriteModels
{
    public class DataProvider : AggregateBase, IDataProvider
    {
        public string Name { get; private set; }
        public IEnumerable<IDataField> DataFields { get; private set; }
        public IEnumerable DataFieldsRevision { get; private set; }

         
        public Type ResponseType { get; private set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider() { }

        public DataProvider(Guid id, string name, Type responseType) : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name, responseType, PopulateDataFields(responseType)));
        }

        //public DataProviderRevision(Guid id, string name, Type responseType, IEnumerable<DataProviderRevisionCreated.DataProviderFieldItems> dataFields) : this(id)
        //{
        //    RaiseEvent(new DataProviderRevisionCreated(id, name, responseType, dataFields));
        //}

        public void CreateDataProviderRevision(Guid id, string name, Type responseType, IEnumerable dataFields)
        {
            RaiseEvent(new DataProviderRevisionCreated(id, name, responseType, dataFields));
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
            DataFields = PopulateDataFields(@event.ResponseType);
        }

        private void Apply(DataProviderRenamed @event)
        {
            Id = @event.Id;
            Name = @event.NewName;
        }

        private void Apply(DataProviderRevisionCreated @event)
        {

            Id = @event.Id;
            Name = @event.Name;
            DataFieldsRevision = @event.DataFields;

        }
    }
}