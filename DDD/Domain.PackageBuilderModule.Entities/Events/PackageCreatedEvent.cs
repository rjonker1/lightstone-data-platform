using System;
using System.Linq;
using DTO.PackageBuilder;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;

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
            var context = new Model.Context();

            context.ChangeTracker.DetectChanges();
            
            //var state = context.CreateState("Under Construction");
            
            var p = context.Packages.Create();

            p.State = package.State;
            p.Name = package.Name;
            p.Owner = package.Owner;
            p.Description = package.Description;
            p.ChangeCurrentIdentity(GuidUtil.NewSequentialId());
            p.State.Id = new Guid("80adc8fe-a229-4b00-a491-818dd0273b16"); // "Under construction"
            p.EntityState = TrackState.Added;

            context.Packages.Add(package);

            context.SaveChanges();
            
            PackageCreated = p;
        }
        
        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public DTO.PackageBuilder.Package PackageCreated { get; private set; }
    }
}