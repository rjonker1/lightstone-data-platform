using System;
using LightstoneApp.Domain.PackageBuilderModule.Entities.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.ComponentModel;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Events
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

            var context = new PackageBuilderContext();

            var packageCreated = context.CreatePackage();

            packageCreated.CreatedChanged +=
                delegate(System.Object o, PropertyChangedEventArgs<Abstract.Package, DateTime?> e)
                {
                    var nv = e.Instance.Created;

                };

            

            PackageCreated = package;
        }

      

        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Package PackageCreated { get; private set; }
    }
}