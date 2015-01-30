using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ProfileDetails;

namespace UserManagement.Domain.CommandHandlers.ProfileDetails
{
    public class CreateProfileDetailHandler : AbstractMessageHandler<CreateProfileDetail>
    {

        private readonly IRepository<ProfileDetail> _repository;

        public CreateProfileDetailHandler(IRepository<ProfileDetail> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateProfileDetail command)
        {

            _repository.Save(new ProfileDetail(command.Id, command.LegalEntityName, command.AccountsContactName, command.EmailAddress, command.TelephoneNumber, command.VATNumber, 
                                                command.Address, command.Address1));
        }
    }
}