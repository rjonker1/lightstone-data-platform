using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public partial class Package : Aggregate
    {
        private Package SetupCompleted()
        {
            var packageCreatedEvent = new PackageCreatedEvent(this);

            RaiseEvent(packageCreatedEvent);

            return this;
        }

        public class Factory
        {
            public Package CreatePackage(string name, string version)
            {
                var package = new Package
                {
                    //Id = "people/" + Guid.NewGuid().ToString(),
                    //Id = IdentityGenerator.NewSequentialGuid(),
                    //Name = name,
                    //Version =  version
                };

                package = package.SetupCompleted();

                return package;
            }

            public Package CreatePackage(Package newPackage)
            {
                var package = newPackage.SetupCompleted();
                return package;
            }
        }
    }
}