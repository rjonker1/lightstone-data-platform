using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.EscalationTypes;

namespace UserManagement.Domain.BusinessRules.Lookups.EscalationTypes
{
    public class DeleteEscalationTypeRuleHandler : AbstractMessageHandler<DeleteEscalationTypeRule>
    {

        private readonly IRepository<Contract> _contractListings;

        public DeleteEscalationTypeRuleHandler(IRepository<Contract> contractListings)
        {
            _contractListings = contractListings;
        }

        public override void Handle(DeleteEscalationTypeRule command)
        {
            var entity = command.Entity;
            var escalationTypes = _contractListings.Select(x => x).Where(x => x.EscalationType.Id.Equals(entity.Id));

            if (escalationTypes.Any())
            {
                var exception = new LightstoneAutoException("EscalationType is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}