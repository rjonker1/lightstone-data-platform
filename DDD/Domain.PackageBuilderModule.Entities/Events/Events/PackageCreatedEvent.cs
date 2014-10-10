using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events.Events
{
    public class PackageCreatedEvent : DomainEvent
    {
        //[JsonConstructor]
        public PackageCreatedEvent()
        {
            Id = IdentityGenerator.NewSequentialGuid();
        }
        public PackageCreatedEvent(Package package)
            : this()
        {
            PackageCreated = package;
        }

        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Package PackageCreated { get; private set; }
    }
}