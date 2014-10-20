using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;


namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public class Package : DTO.PackageBuilder.Package
    {
        private Package SetupCompleted()
        {
            var packageCreatedEvent = new PackageCreatedEvent(this);

            RaiseEvent(packageCreatedEvent);

            return this;
        }

        public class Factory
        {
            public Package CreatePackage(string name, string owner, string description, string version)
            {
                Version checkVersion;

                Infrastructure.CrossCutting.NetFramework.Version.TryParse(version, out checkVersion);

                if (checkVersion != null)
                {

                    var package = new Package();
                   
                        //Id = "people/" + Guid.NewGuid().ToString(),
                   // Id = IdentityGenerator.NewSequentialGuid();
                    package.Name = name;
                    package.Owner = owner;
                    package.Version = checkVersion.ToString();
                    package.Description = description;

                    package = package.SetupCompleted();

                    //package.Id = GuidUtil.NewSequentialId();

                    return package;
                }
                return null;
            }

            public Package CreatePackage(Package newPackage)
            {
                var package = newPackage.SetupCompleted();
                return package;
            }
        }

       


        public override object Clone()
        {
            var version = new Version(Version);

            var revisionNr = version.Revision + 1;

            var newVersion = new Version(version.Major, version.Minor, version.Publish, revisionNr).ToString();

            var clone = MemberwiseClone() as Package;

            if (clone != null)
            {
                var package = base.Clone() as Package;

                if (package != null)
                {
                    package.Version = newVersion;

                    var pce = new PackageClonedEvent(package);

                    return pce.PackageCreated;
                }
            }

            return null;
        }

       
    }
}