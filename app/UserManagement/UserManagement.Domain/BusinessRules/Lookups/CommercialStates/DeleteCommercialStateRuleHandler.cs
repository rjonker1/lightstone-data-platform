using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.CommercialStates;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Domain.BusinessRules.Lookups.CommercialStates
{
    public class DeleteCommercialStateRuleHandler : AbstractMessageHandler<DeleteCommercialStateRule>
    {

        private readonly IRepository<Customer> _customerListings;

        public DeleteCommercialStateRuleHandler(IRepository<Customer> customerListings)
        {
            _customerListings = customerListings;
        }

        public override void Handle(DeleteCommercialStateRule command)
        {

            var entity = command.Entity;
            var commercialStates = _customerListings.Select(x => x).Where(x => x.CommercialState.Id.Equals(entity.Id));

            if (commercialStates.Any())
            {
                var exception = new LightstoneAutoException("Create Source is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}