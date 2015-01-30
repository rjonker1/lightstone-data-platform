using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Addresses;

namespace UserManagement.Domain.CommandHandlers.Addresses
{
    public class CreateAddressHandler : AbstractMessageHandler<CreateAddress>
    {

        private readonly IRepository<Address> _repository;

        public CreateAddressHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateAddress command)
        {

            _repository.Save(new Address(command.Id, command.AddressType, command.Line1, command.Line2, command.PostalCode, command.City, command.Country, command.Province));
        }
    }
}