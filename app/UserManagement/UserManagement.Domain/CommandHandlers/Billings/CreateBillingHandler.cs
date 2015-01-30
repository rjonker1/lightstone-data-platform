using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Billings;

namespace UserManagement.Domain.CommandHandlers.Billings
{
    public class CreateBillingHandler : AbstractMessageHandler<CreateBilling>
    {

        private readonly IRepository<Billing> _repository;

        public CreateBillingHandler(IRepository<Billing> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateBilling command)
        {
            
            _repository.Save(new Billing(command.Id, command.BillingContactNumber, command.BillingContractPersion, command.CompanyRegistration, command.FirstCreateDate,
                                            command.DebitOrderDate, command.PaymentType));
        }
    }
}