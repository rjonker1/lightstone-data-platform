using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Provinces;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Domain.BusinessRules.Lookups.Provinces
{
    public class DeleteProvinceRuleHandler : AbstractMessageHandler<DeleteProvinceRule>
    {

        private readonly IRepository<Address> _addressListings;

        public DeleteProvinceRuleHandler(IRepository<Address> addressListings)
        {
            _addressListings = addressListings;
        }

        public override void Handle(DeleteProvinceRule command)
        {
            var entity = command.Entity;
            var provinces = _addressListings.Select(x => x).Where(x => x.Province.Id.Equals(entity.Id));

            if (provinces.Any())
            {
                var exception = new LightstoneAutoException("Province is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}