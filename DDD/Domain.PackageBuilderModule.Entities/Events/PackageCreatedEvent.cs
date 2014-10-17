using System;
using System.Globalization;
using System.Linq;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Context.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

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

            var state = context.CreateState(DTO.PackageBuilder.State.ConstraintValues.First().ToString(CultureInfo.InvariantCulture));

            var packageCreated = context.CreatePackage(package.Name, "", Version, context.CreateState(state.ToString()));

            PackageCreated = packageCreated;
        }


        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public DTO.PackageBuilder.Package PackageCreated { get; private set; }
    }
}