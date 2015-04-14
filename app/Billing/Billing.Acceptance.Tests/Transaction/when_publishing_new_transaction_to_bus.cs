using System;
//using DataPlatform.Shared.Messaging.Billing.Messages;
//using EasyNetQ;
//using EasyNetQ.Topology;
//using Shared.Messaging.Billing.Helpers;
//using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    //public class when_publishing_new_transaction_to_bus : Specification
    //{
    //    private readonly IAdvancedBus _bus;
    //    private InvoiceTransactionCreated transaction;

    //    public when_publishing_new_transaction_to_bus()
    //    {
    //        _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
    //    }

    //    public override void Observe()
    //    {
    //        var bus = new TransactionBus(_bus);

    //        transaction = new InvoiceTransactionCreated(Guid.NewGuid());

    //        //var message = (IMessage<InvoiceTransactionCreated>) (transaction);

    //        bus.Send(transaction, "TESTEXCHANGE1", "TESTQUEUE1");
    //    }

    //    [Observation]
    //    public void it_should_publish_a_transaction()
    //    {
    //        _bus.ShouldNotBeNull();
    //    }
    //}
}