using System;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;



namespace LightstoneApp.Domain.PackageBuilderModule.Entities.Model
{
    public partial class Package
    {

        public const string StateUnderConsructionKey = "80adc8fe-a229-4b00-a491-818dd0273b16";
        public const string IndustryOtherKey = "a5f908f8-f645-4c94-93f5-fedbc9781f8c";

        private Package SetupCompleted()
        {
            var packageCreatedEvent = new PackageCreatedEvent(this);

            //TODO: RaiseEvent
            //RaiseEvent(packageCreatedEvent);

            return this;
        }

        public class Factory
        {
            public Package CreatePackage(string name, string owner, string description, string version)
            {
                Infrastructure.CrossCutting.NetFramework.Version checkVersion;

                Infrastructure.CrossCutting.NetFramework.Version.TryParse(version, out checkVersion);

                if (checkVersion != null)
                {
                    var package = new Package
                    {
                        Id = GuidUtil.NewSequentialId(),
                        Name = name,
                        Owner = owner,
                        Version = checkVersion.ToString(),
                        Description = description,
                        Published = false,
                        StateId = new Guid(StateUnderConsructionKey),
                        IndustryId = new Guid(IndustryOtherKey),
                        Created = DateTime.Now
                    };

                    try
                    {
                        package = package.SetupCompleted();

                        return package;
                    }
                    catch(Exception exception)
                    {

                        throw new Exception("Error creating Package :", exception);
                    }
                }
                return null;
            }

            public Package CreatePackage(Package newPackage)
            {
                var package = newPackage.SetupCompleted();
                return package;
            }
        }



    }
}