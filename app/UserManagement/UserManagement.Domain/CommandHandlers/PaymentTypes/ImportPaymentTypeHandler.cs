using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.PaymentTypes;

namespace UserManagement.Domain.CommandHandlers.PaymentTypes
{
    public class ImportPaymentTypeHandler : AbstractMessageHandler<ImportPaymentType>
    {
         private readonly IBus _bus;

         public ImportPaymentTypeHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportPaymentType command)
        {
            _bus.Publish(new CreateUpdateEntity(new PaymentType("Debit Order"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new PaymentType("EFT"), "Create"));
        }
    }
}