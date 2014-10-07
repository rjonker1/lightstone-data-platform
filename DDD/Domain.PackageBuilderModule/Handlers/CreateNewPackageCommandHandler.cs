using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    class CreateNewPersonCommandHandler : IHandleMessages<CreateNewPackageCommand>
    {
        public IRepositoryFactory RepositoryFactory { get; set; }
        public Package.Factory PackageFactory { get; set; }

        public void Handle(CreateNewPackageCommand message)
        {
            using (var repository = this.RepositoryFactory.OpenSession())
            {
                var package = this.PackageFactory.CreatePackage(message.Name,message.Version);

                repository.Save(package);
                repository.CommitChanges();
            }
        }
    }
}
