using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractDurations;

namespace UserManagement.Domain.BusinessRules.Lookups.ContractDurations
{
    public class DeleteContractDurationRuleHandler : AbstractMessageHandler<DeleteContractDurationRule>
    {

        private readonly IRepository<Contract> _contractListings;

        public DeleteContractDurationRuleHandler(IRepository<Contract> contractListings)
        {
            _contractListings = contractListings;
        }

        public override void Handle(DeleteContractDurationRule command)
        {
            var entity = command.Entity;
            var contractDurations = _contractListings.Select(x => x).Where(x => x.ContractDuration != null);

            if (contractDurations.Any())
            {
                var exception = new LightstoneAutoException("Contract Duration is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}