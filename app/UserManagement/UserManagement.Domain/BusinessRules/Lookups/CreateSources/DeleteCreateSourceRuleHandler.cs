using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.CreateSources;

namespace UserManagement.Domain.BusinessRules.Lookups.CreateSources
{
    public class DeleteCreateSourceRuleHandler : AbstractMessageHandler<DeleteCreateSourceRule>
    {

        private readonly IRepository<Customer> _customerListings;

        public DeleteCreateSourceRuleHandler(IRepository<Customer> customerListings)
        {
            _customerListings = customerListings;
        }

        public override void Handle(DeleteCreateSourceRule command)
        {
            var entity = command.Entity;
            var createSources = _customerListings.Select(x => x).Where(x => x.CreateSource.Id.Equals(entity.Id));

            if (createSources.Any())
            {
                var exception = new LightstoneAutoException("Create Source is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}