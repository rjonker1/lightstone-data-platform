using System;
using LightstoneApp.Domain.PackageBuilderModule.Commands;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;

namespace LightstoneApp.Domain.PackageBuilderModule.Handlers
{
    public interface IRepositoryFactory
    {
        IRepository OpenSession();
    }

    public interface IRepository : IDisposable
    {
        void Save<TAggregate>(TAggregate aggregate) where TAggregate : IAggregate;
        void CommitChanges();

        TAggregate GetById<TAggregate>(String aggregateId) where TAggregate : IAggregate;

        TAggregate[] GetById<TAggregate>(params string[] aggregateIds) where TAggregate : IAggregate;
    }

    internal class CreateNewPersonCommandHandler : IHandleMessages<CreateNewPackageCommand>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Package.Factory PackageFactory { get; set; }

        public void Handle(CreateNewPackageCommand message)
        {
            using (IRepository repository = RepositoryFactory.OpenSession())
            {
                Package package = PackageFactory.CreatePackage(message.Name, message.Version);

                repository.Save(package);
                repository.CommitChanges();
            }
        }
    }
}