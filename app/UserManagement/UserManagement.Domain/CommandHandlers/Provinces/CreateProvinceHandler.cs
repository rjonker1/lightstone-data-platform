using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Provinces;

namespace UserManagement.Domain.CommandHandlers.Provinces
{
    public class CreateProvinceHandler : AbstractMessageHandler<CreateProvince>
    {

        private readonly INamedEntityRepository<Province> _repository;

        public CreateProvinceHandler(INamedEntityRepository<Province> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateProvince command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new Province(command.Id, command.Name));
        }
    }
}