using System;
using EasyNetQ;
using Workflow.BuildingBlocks;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Transaction
{
    //public class when_publishing_new_transaction_to_queue : Specification
    //{
    //    private readonly IAdvancedBus _bus;
    //    private InvoiceTransactionCreated transaction;

    //    public when_publishing_new_transaction_to_queue()
    //    {
    //        _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
    //    }

    //    public override void Observe()
    //    {
    //        var bus = new TransactionBus(_bus);

    //        transaction = new InvoiceTransactionCreated(new Guid("70b36ed9-2cbd-41e7-a22e-e708fd00156b"));
    //        //bus.Send(transaction, "DataPlatform.Transactions.Billing", "DataPlatform.Transactions.Billing");
    //        //bus.SendDynamic(transaction);
    //    }

    //    [Observation]
    //    public void it_should_publish_a_transaction()
    //    {
    //        _bus.ShouldNotBeNull();
    //    }
    //}
}