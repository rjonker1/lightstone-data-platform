using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.PaymentTypes;

namespace UserManagement.Domain.CommandHandlers.PaymentTypes
{
    public class CreatePaymentTypeHandler : AbstractMessageHandler<CreatePaymentType>
    {
        private readonly INamedEntityRepository<PaymentType> _repository;

        public CreatePaymentTypeHandler(INamedEntityRepository<PaymentType> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreatePaymentType command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new PaymentType(command.Name));
        }
    }
}