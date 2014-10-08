using System.ComponentModel;
using LightstoneApp.Domain.Core.Entities;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public partial class Package
    {

        Package SetupCompleted()
        {

            RaiseEvent(new PackageCreated(this.Id.ToString(), this.Name, this.Version));

            return this;
        }

        public class Factory
        {
            public Package CreatePackage(string name, int version)
            {
                var package = new Package()
                {
                    //Id = "people/" + Guid.NewGuid().ToString(),
                    Id = IdentityGenerator.NewSequentialGuid(),
                    Name = name,
                    Version = version
                };

                package = package.SetupCompleted();

                return package;
            }
        }
    }
}
