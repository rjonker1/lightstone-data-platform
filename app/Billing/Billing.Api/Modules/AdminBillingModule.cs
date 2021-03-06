﻿using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Nancy;
using Nancy.Responses.Negotiation;
using Nancy.Security;
using Workflow.Billing.Domain.Entities;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Messages.Publishable;


namespace Billing.Api.Modules
{
    public class AdminBillingModule : SecureModule
    {
        public AdminBillingModule(IRepository<AuditLog> auditLogs, IRepository<Transaction> transactions, IAdvancedBus eBus)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

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
                try
                {
                    foreach (var transaction in transactions)
                    {
                        var message = new InvoiceTransactionCreated(transaction.Id);
                        advancedBus.SendDynamic(message);
                    }
                }
                catch (Exception ex)
                {
                    throw new LightstoneAutoException(ex.Message);
                }

                return Response.AsJson(new { data = "Success" });
            };

            Post["/Admin/Cache/Flush/{cycle}"] = param =>
            {
                string billingCycle = param.cycle;

                try
                {
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
                }
                catch (Exception ex)
                {
                    throw new LightstoneAutoException(ex.Message);
                }

                return Response.AsJson(new { data = "Success" });
            };

            Post["/Admin/Cache/Reload/{cycle}"] = param =>
            {
                string billingCycle = param.cycle;

                try
                {
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
                }
                catch (Exception ex)
                {
                    throw new LightstoneAutoException(ex.Message);
                }

                return Response.AsJson(new { data = "Success" });
            };
        }
    }
}