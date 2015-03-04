using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.PlatformStatuses;

namespace UserManagement.Domain.BusinessRules.Lookups.PlatformStatuses
{
    public class DeletePlatformStatusRuleHandler : AbstractMessageHandler<DeletePlatformStatusRule>
    {

        private readonly IRepository<Customer> _customerListings;

        public DeletePlatformStatusRuleHandler(IRepository<Customer> customerListings)
        {
            _customerListings = customerListings;
        }

        public override void Handle(DeletePlatformStatusRule command)
        {
            var entity = command.Entity;
            var platformStatuses = _customerListings.Select(x => x).Where(x => x.PlatformStatus != null);

            if (platformStatuses.Any())
            {
                var exception = new LightstoneAutoException("Platform Status is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}