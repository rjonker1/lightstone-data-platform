using System;
using System.Collections.Generic;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataProviders.Events;

namespace PackageBuilder.Domain.DataProviders
{
    public class DataProvider : AggregateBase, IDataProvider
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<IDataField> DataFields { get; private set; }
        public Type ResponseType { get; private set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider(Guid id, string name) : this(id)
        {
            RaiseEvent(new DataProviderCreated(id, name));
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
                RaiseEvent(new DataProviderRenamed(Id, newName));
        }

        private void Apply(DataProviderCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
        }

        private void Apply(DataProviderRenamed @event)
        {
            Id = @event.Id;
            Name = @event.NewName;
        }
    }
}