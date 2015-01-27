using UserManagement.Domain.Core.MessageHandling;
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

            _handler.Handle(new CreatePaymentType("Debit Order"));
            _handler.Handle(new CreatePaymentType("EFT"));
        }
    }
}