using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractTypes;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Domain.BusinessRules.Lookups.ContractTypes
{
    public class DeleteContractTypeRuleHandler : AbstractMessageHandler<DeleteContractTypeRule>
    {

        private readonly IRepository<Contract> _contractListings;

        public DeleteContractTypeRuleHandler(IRepository<Contract> contractListings)
        {
            _contractListings = contractListings;
        }

        public override void Handle(DeleteContractTypeRule command)
        {
            var entity = command.Entity;
            var contractTypes = _contractListings.Select(x => x).Where(x => x.ContractType.Id.Equals(entity.Id));

            if (contractTypes.Any())
            {
                var exception = new LightstoneAutoException("ContractType is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}