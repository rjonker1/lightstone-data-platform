using System;
using CommonDomain.Core;
using PackageBuilder.Domain.Entities.DataProviders.Events;

namespace PackageBuilder.Domain.Entities.DataProviders.ReadModels
{
    public class DataProviderReadModel : AggregateBase
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public int Version { get; set; }

        public void UpdateReadModel(Guid id, string name, int version)
        {
            RaiseEvent(new ReadModelUpdated(id, name, version));
        }

        private void Apply(ReadModelUpdated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            Version = @event.Version;
        }
    }
}