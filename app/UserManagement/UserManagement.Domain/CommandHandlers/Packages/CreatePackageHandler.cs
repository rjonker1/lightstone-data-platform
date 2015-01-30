using System;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Packages;

namespace UserManagement.Domain.CommandHandlers.Packages
{
    public class CreatePackageHandler : AbstractMessageHandler<CreatePackage>
    {

        private readonly IRepository<Package> _repository;

        public CreatePackageHandler(IRepository<Package> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreatePackage command)
        {

            _repository.Save(new Package(command.Id, command.LastUpdateBy, command.LastUpdateDate, command.Name, command.Version, command.IsActivated));
        }
    }
}