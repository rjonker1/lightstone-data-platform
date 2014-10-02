using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageBuilder.Core.Helpers.Cqrs.Events;

namespace PackageBuilder.Domain.DataProviders.Events
{
    public class ReadModelUpdated : DomainEvent
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Version { get; private set; }

        public ReadModelUpdated(Guid id, string name, int version)
        {
            Id = id;
            Name = name;
            Version = version;
        }

    }
}
