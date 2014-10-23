using System;
using LightstoneApp.Domain.PackageBuilderModule.Events;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;

namespace LightstoneApp.Domain.PackageBuilderModule.Entities
{
    public partial class Package : IAggregateRoot
    {
        private Package SetupCompleted()
        {
            ChangeCurrentIdentity(Id);
          
            var packageCreatedEvent = new PackageCreatedEvent(this);

            RaiseEvent(packageCreatedEvent);

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
                        StateId = Constants.StateKeys.UnderConstruction,
                        //IndustryId = Constants.IndustryKeys.Other,
                        Created = DateTime.Now,
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