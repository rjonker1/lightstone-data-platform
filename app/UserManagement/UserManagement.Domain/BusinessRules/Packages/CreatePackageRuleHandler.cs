using System.Linq;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.BusinessRules.Packages;

namespace UserManagement.Domain.BusinessRules.Packages
{
    public class CreatePackageRuleHandler : AbstractMessageHandler<CreatePackageRule>
    {

        private readonly IRepository<Package> _currentPackages;

        public CreatePackageRuleHandler(IRepository<Package> currentPackages)
        {
            _currentPackages = currentPackages;
        }

        public override void Handle(CreatePackageRule command)
        {

            var entity = command.Entity;

            //Check if Username for specific user already exists
            if (Enumerable.Any(_currentPackages, client => client.Name.Equals(entity.Name)))
            {
                var exception = new LightstoneAutoException("Package already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}