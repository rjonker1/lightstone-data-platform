using System;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataProviders.Commands;
using PackageBuilder.Domain.DataProviders.Events;
using Raven.Client;

namespace PackageBuilder.Domain.DataProviders.ReadModels
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