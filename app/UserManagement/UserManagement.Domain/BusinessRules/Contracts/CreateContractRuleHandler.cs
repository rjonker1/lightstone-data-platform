using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Contracts;

namespace UserManagement.Domain.BusinessRules.Contracts
{
    public class CreateContractRuleHandler : AbstractMessageHandler<CreateContractRule>
    {
        private readonly INamedEntityRepository<Contract> _repository;

        public CreateContractRuleHandler(INamedEntityRepository<Contract> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateContractRule command)
        {
            var entity = command.Entity;

            //Check if Username for specific user already exists
            if (_repository.Exists(entity.Id, entity.Name))
            {
                var exception = new LightstoneAutoException("Contract already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}