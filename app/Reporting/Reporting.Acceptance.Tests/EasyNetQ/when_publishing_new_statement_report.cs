using System;
using System.Collections.Generic;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Newtonsoft.Json;
using Workflow.BuildingBlocks;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;
using Xunit.Extensions;

namespace Reporting.Acceptance.Tests.EasyNetQ
{
    public class when_publishing_new_statement_report : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_statement_report()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var userTransactions = new List<ContractUserTransactions>();
            var products = new List<ContractProductDetail>();
            products.Add(new ContractProductDetail { PackageName = "Test Package", TransactionCount = 12 });

            userTransactions.Add(new ContractUserTransactions
            {
                User = "Test User",
                Products = products
            });

            var statementList = new List<ContractStatement>();

            statementList.Add(new ContractStatement
             {
                 Customer = "Test Customer",
                 Client = "",
                 ContractName = "Test Contract",
                 UserTransactions = userTransactions
             });

            var data = new ReportDto
            {
                Template = new ReportTemplate { ShortId = "VkTYTvzp" },
                Data = new ReportData
                {
                    ContractStatements = statementList
                }
            };


            var report = new ReportMessage()
            {
                Id = Guid.NewGuid(),
                ReportBody = JsonConvert.SerializeObject(data),
                ReportType = "pdf"
            };

            bus.SendDynamic(report);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }
}