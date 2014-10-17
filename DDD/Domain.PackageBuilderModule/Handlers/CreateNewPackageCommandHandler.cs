using LightstoneApp.Domain.PackageBuilderModule.Commands;
using LightstoneApp.Domain.PackageBuilderModule.Entities.DTO.PackageBuilder;
using LightstoneApp.Domain.PackageBuilderModule.Interfaces;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Package = LightstoneApp.Domain.PackageBuilderModule.Entities.Package;

namespace LightstoneApp.Domain.PackageBuilderModule.Handlers
{
    internal class CreateNewPackageCommandHandler : IHandleMessages<CreateNewPackageCommand>
    {
        private IRepositoryFactory RepositoryFactory { get; set; }
        private Package.Factory PackageFactory { get; set; }

        public CreateNewPackageCommandHandler(IPackageBuilderContext context, IRepositoryFactory repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
            PackageFactory = new Package.Factory(context);
        }

        public void Handle(CreateNewPackageCommand message)
        {
            using (var repository = RepositoryFactory.OpenSession())
            {
                if (PackageFactory != null)
                {
                    var package = PackageFactory.CreatePackage(message.NewPackage);

                    repository.Save(package);
                }
                repository.CommitChanges();
            }
        }
    }
}