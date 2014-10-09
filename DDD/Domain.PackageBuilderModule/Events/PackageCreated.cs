using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Events
{
    public class PackageCreated : DomainEvent
    {
        //[JsonConstructor]
        public PackageCreated()
        {
        }

        public PackageCreated(String aggregateId, string name, string version)
            : base(aggregateId)
        {
            Name = name;
            Version = version;
        }

        public string Name { get; private set; }
        public string Version { get; private set; }
    }
}