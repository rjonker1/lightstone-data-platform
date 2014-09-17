using System;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataProviders.Events;

namespace PackageBuilder.Domain.DataProviders
{
    public class DataProvider : AggregateBase, IDataProvider
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Type ResponseType { get; private set; }

        private DataProvider(Guid id)
        {
            Id = id;
        }

        public DataProvider(Guid id, string name) : this(id)
        {
            RaiseEvent(new DataProviderCreatedEvent(id, name));
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("newName");
                RaiseEvent(new DataProviderRenamedEvent(Id, newName));
        }

        private void Apply(DataProviderCreatedEvent @event)
        {
            Id = @event.Id;
            Name = @event.Name;
        }

        private void Apply(DataProviderRenamedEvent @event)
        {
            Id = @event.Id;
            Name = @event.NewName;
        }
    }
}