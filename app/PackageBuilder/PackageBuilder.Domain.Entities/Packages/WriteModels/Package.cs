using System;
using System.Collections.Generic;
using CommonDomain.Core;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.Events;

namespace PackageBuilder.Domain.Entities.Packages.WriteModels
{
    public class Package : AggregateBase, IPackage
    {
        public string Name { get; private set; }
        public IAction Action { get; set; }
        public IEnumerable<IDataProvider> DataProviders { get; private set; }
        public IEnumerable<IWorkflow> Workflows { get; set; }

        public Package(Guid Id)
        {
        }

        public Package(Guid id, string name, IEnumerable<IDataProvider> dataProviders)
            : this(id)
        {
            RaiseEvent(new PackageCreated(id, name, dataProviders));
        }

        private void Apply(PackageCreated @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            DataProviders = @event.DataProviders;
        }
    }
}