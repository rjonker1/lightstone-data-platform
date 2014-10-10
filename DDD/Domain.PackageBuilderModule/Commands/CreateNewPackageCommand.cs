using System;
using System.Windows.Input;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Commands
{
    public class CreateNewPackageCommand :  IDomainEvent
    {

        public CreateNewPackageCommand()
        {
            
        }

        public CreateNewPackageCommand(Package package) : this()
        {
            NewPackage = package.Clone<Package>();
        }

        public Package NewPackage { get; private set; }


        public string Id { get; private set; }
        public string AggregateId { get; private set; }
        public int AggregateVersion { get; private set; }
        public DateTimeOffset OccurredAt { get; private set; }
    }
}