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

            var products = new List<ContractProductDetail>
            {
                new ContractProductDetail {PackageName = "Test Package", TransactionCount = 12}
            };

            var userTransactions = new List<ContractUserTransactions>
            {
                new ContractUserTransactions
                {
                    User = "Test User",
                    Products = products
                }
            };

            var pricingSummaries = new List<PricingSummary>
            {
                new PricingSummary
                {
                    ContractName = "Test Contract",
                    Description = "Test",
                    PackageName = "Test Package"
                }
            };

            var data = new ReportDto
            {
                Template = new ReportTemplate { ShortId = "VkTYTvzp" },
                Data = new ReportData
                {
                    CustomerClientStatement = new CustomerClientStatement
                     {
                         StatementPeriod = "9999/99/99",
                         CustomerClientName = "Customer 1",
                         TaxRegistration = "4190195679",
                         ConsultantName = "TC",
                         AccountContact = "123456",
                         AccountNumber = "Cus00012",
                         ContractName = "Test Contract",
                         UserTransactions = userTransactions,
                         PricingSummaries = pricingSummaries
                     }
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