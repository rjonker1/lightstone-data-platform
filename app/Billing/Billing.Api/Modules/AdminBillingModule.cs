using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Nancy;
using Nancy.Extensions;
using Nancy.Responses.Negotiation;
using Workflow.Billing.Domain.Entities;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Messages.Publishable;
using Workflow.Billing.Repository;


namespace Billing.Api.Modules
{
    public class AdminBillingModule : SecureModule
    {
        public AdminBillingModule(IRepository<AuditLog> auditLogs, IRepository<Transaction> transactions, IAdvancedBus eBus)
        {
            var advancedBus = new TransactionBus(eBus);

            Get["/Admin/Billing"] = _ => Negotiate.WithView("Index");
            Get["/Admin/AuditLog"] = _ =>
            {
                return Negotiate
                    .WithView("AuditLog")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = auditLogs });
            };

            Post["/Admin/Replay/BillingTransactions"] = _ =>
            {
                foreach (var transaction in transactions)
                {
                    var message = new InvoiceTransactionCreated(transaction.Id);
                    advancedBus.SendDynamic(message);
                }
                return Response.AsJson(new { data = "Success" });
            };

            Post["/Admin/Cache/Flush/{cycle}"] = param =>
            {
                string billingCycle = param.cycle;

                switch (billingCycle)
                {
                    case "preBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(PreBilling), Command = BillingCacheCommand.Flush });
                        break;

                    case "stageBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(StageBilling), Command = BillingCacheCommand.Flush });
                        break;

                    case "finalBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(FinalBilling), Command = BillingCacheCommand.Flush });
                        break;
                }

                return Response.AsJson(new { data = "Success" });
            };

            Post["/Admin/Cache/Reload/{cycle}"] = param =>
            {
                string billingCycle = param.cycle;

                switch (billingCycle)
                {
                    case "preBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(PreBilling), Command = BillingCacheCommand.Reload });
                        break;

                    case "stageBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(StageBilling), Command = BillingCacheCommand.Reload });
                        break;

                    case "finalBilling":
                        advancedBus.SendDynamic(new BillCacheMessage { BillingType = typeof(FinalBilling), Command = BillingCacheCommand.Reload });
                        break;
                }

                return Response.AsJson(new { data = "Success" });
            };
        }
    }
}