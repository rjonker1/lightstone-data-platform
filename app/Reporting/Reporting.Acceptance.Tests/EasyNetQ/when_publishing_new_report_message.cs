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
    public class when_publishing_new_report_message : Specification
    {
        private readonly IAdvancedBus _bus;

        public when_publishing_new_report_message()
        {
            _bus = BusFactory.CreateAdvancedBus("workflow/billing/queue");
        }

        public override void Observe()
        {
            var bus = new TransactionBus(_bus);

            var packagesList = new List<ReportPackage>();
            packagesList.Add(new ReportPackage()
            {
                ItemCode = "1000/200/002",
                ItemDescription = "PackageName",
                QuantityUnit = 1,
                Price = 16314.67,
                Vat = 2284,
                Total = 18598.72
            });

            var data = new ReportDto()
            {
                Template = new ReportTemplate() { ShortId = "VJGAd9OM" },
                Data = new ReportData()
                {
                    Customer = new ReportCustomer()
                    {
                        Name = "Customer 1",
                        TaxRegistration = 4190195679,
                        Packages = packagesList
                    }
                }
            };


            var report = new ReportMessage()
            {
                Id = Guid.NewGuid(),
                ReportBody = JsonConvert.SerializeObject(data)
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