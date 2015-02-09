using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Clients;

namespace UserManagement.Domain.CommandHandlers.Clients
{
    public class CreateUpdateClientHandler : AbstractMessageHandler<CreateUpdateClient>
    {
        private readonly IRepository<Client> _repository;

        public CreateUpdateClientHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUpdateClient command)
        {
            var customer = _repository.Get(command.Id);
            if (customer == null)
                _repository.Save(new Client(command.Id, command.ClientName));
            else
                customer.UpdateName(command.ClientName);
        }
    }
}