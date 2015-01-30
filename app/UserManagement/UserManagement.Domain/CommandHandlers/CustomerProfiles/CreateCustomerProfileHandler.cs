using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CustomerProfiles;

namespace UserManagement.Domain.CommandHandlers.CustomerProfiles
{
    public class CreateCustomerProfileHandler : AbstractMessageHandler<CreateCustomerProfile>
    {

        private readonly IRepository<CustomerProfile> _repository;

        public CreateCustomerProfileHandler(IRepository<CustomerProfile> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateCustomerProfile command)
        {

            _repository.Save(new CustomerProfile(command.Id, command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate, command.PastelID, command.Billing, command.CommercialState,
                                                    command.CreateSource, command.Customer, command.PlatformStatus, command.ProfileDetail));
        }
    }
}