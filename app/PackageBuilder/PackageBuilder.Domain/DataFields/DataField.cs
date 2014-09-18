using System;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataFields.Events;

namespace PackageBuilder.Domain.DataFields
{
    public class DataField : AggregateBase, IDataField
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public IDataProvider DataProvider { get; set; }
        public Guid DataProviderId { get; set; }

        private DataField(Guid id)
        {
            Id = id;
        }
        public DataField(Guid id, string name, Type type, Guid dataProviderId) : this(id)
        {
            RaiseEvent(new DataFieldCreated(id, name, type, dataProviderId));
        }

        private void Apply(DataFieldCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Type = @event.Type;
            DataProviderId = @event.DataProviderId;
        }
    }
}