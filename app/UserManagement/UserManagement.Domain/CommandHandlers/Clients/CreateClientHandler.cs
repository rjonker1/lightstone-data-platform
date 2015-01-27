using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Clients;

namespace UserManagement.Domain.CommandHandlers.Clients
{
    public class CreateClientHandler : AbstractMessageHandler<CreateClient>
    {

        private readonly IRepository<Client> _repository;

        public CreateClientHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateClient command)
        {
            
            _repository.Save(new Client(command.Id, command.ClientName));
        }
    }
}