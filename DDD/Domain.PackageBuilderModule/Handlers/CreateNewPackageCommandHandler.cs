using LightstoneApp.Domain.PackageBuilderModule.Commands;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Domain.PackageBuilderModule.Interfaces;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Handlers
{
    internal class CreateNewPackageCommandHandler : IHandleMessages<CreateNewPackageCommand>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Package.Factory PackageFactory { get; set; }

        public void Handle(CreateNewPackageCommand message)
        {
            using (var repository = RepositoryFactory.OpenSession())
            {
                var package = PackageFactory.CreatePackage(message.NewPackage);

                repository.Save(package);
                repository.CommitChanges();
            }
        }
    }
}