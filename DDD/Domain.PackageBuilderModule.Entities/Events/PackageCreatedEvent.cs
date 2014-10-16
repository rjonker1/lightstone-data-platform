using System;
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
            //var context = new PackageBuilderContext();



            //context.CreateName(package.Name);


          //  var packageCreated = context.CreatePackage(package.Description, package.Version, Name);

           
            

            PackageCreated = package;
        }

       


        public new Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Version { get; private set; }

        public Package PackageCreated { get; private set; }
    }
}