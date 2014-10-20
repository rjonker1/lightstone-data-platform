using LightstoneApp.Domain.PackageBuilderModule.Commands;
using LightstoneApp.Domain.PackageBuilderModule.Entities.Model;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Package = LightstoneApp.Domain.PackageBuilderModule.Entities.Package;

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
            using (var repository = new Context())
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