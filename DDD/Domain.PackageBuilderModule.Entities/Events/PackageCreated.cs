using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
{
    public class PackageCreated : DomainEvent
    {
        //[JsonConstructor]
        public PackageCreated() { }

        public PackageCreated(String aggregateId, string name, int version)
            : base(aggregateId)
        {
            Name = name;
            Version = version;
        }

        public string Name { get; private set; }
        public int Version { get; private set; }
    }
}
