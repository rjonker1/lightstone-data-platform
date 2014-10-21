
using LightstoneApp.Domain.PackageBuilderModule.Commands;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Model;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Handlers
{
    internal class CreateNewPackageCommandHandler : IHandleMessages<CreateNewPackageCommand>
    {
        
        private Package.Factory PackageFactory { get; set; }

        public CreateNewPackageCommandHandler()
        {
            PackageFactory = new Package.Factory();
        }

        public void Handle(CreateNewPackageCommand message)
        {
            using (var repository = new LightstoneAppDatabaseEntities())
            {
                if (PackageFactory != null)
                {
                    var package = PackageFactory.CreatePackage(message.NewPackage);

                    repository.Packages.Add(package);
                }
                repository.SaveChanges();
            }
        }
    }
}