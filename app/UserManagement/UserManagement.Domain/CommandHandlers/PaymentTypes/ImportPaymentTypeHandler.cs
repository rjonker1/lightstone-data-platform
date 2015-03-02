using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.PaymentTypes;

namespace UserManagement.Domain.CommandHandlers.PaymentTypes
{
    public class ImportPaymentTypeHandler : AbstractMessageHandler<ImportPaymentType>
    {
        private readonly IHandleMessages _handler;

        public ImportPaymentTypeHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportPaymentType command)
        {
            _handler.Handle(new ValueEntityDto("Debit Order", typeof(PaymentType)));
            _handler.Handle(new ValueEntityDto("EFT", typeof(PaymentType)));
        }
    }
}