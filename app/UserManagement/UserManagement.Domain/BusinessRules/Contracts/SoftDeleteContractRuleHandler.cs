using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Contracts;

namespace UserManagement.Domain.BusinessRules.Contracts
{
    public class SoftDeleteContractRuleHandler : AbstractMessageHandler<SoftDeleteContractRule>
    {
        private readonly IRepository<Contract> _contracts;

        public SoftDeleteContractRuleHandler(IRepository<Contract> contracts)
        {
            _contracts = contracts;
        }

        public override void Handle(SoftDeleteContractRule command)
        {
            var entity = command.Entity;

            var hasClients = _contracts.Where(x => x.Id.Equals(entity.Id)).Select(u => u.Clients.Where(cl => cl.IsActive)).ToList();
            var hasCustomers = _contracts.Where(x => x.Id.Equals(entity.Id)).Select(u => u.Customers.Where(cus => cus.IsActive)).ToList();
            var hasPackages = _contracts.Where(x => x.Id.Equals(entity.Id)).Select(u => u.Packages.Where(pkg => pkg.IsActive)).ToList();

            if (hasClients.Any(x => x.Any()))
            {
                var exception = new LightstoneAutoException("Contract cannot be deleted due to Client constraint".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            if (hasCustomers.Any(x => x.Any()))
            {
                var exception = new LightstoneAutoException("Contract cannot be deleted due to Customer constraint".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            if (hasPackages.Any(x => x.Any()))
            {
                var exception = new LightstoneAutoException("Contract cannot be deleted due to Package constraint".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            entity.Activate(false);
        }
    }
}