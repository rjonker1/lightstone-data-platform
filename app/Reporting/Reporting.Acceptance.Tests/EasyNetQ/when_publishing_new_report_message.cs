using System;
using System.Collections.Generic;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using EasyNetQ;
using Newtonsoft.Json;
using Workflow.BuildingBlocks;
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

            var packagesList = new List<Package>();
            packagesList.Add(new Package()
            {
                ItemCode = "1000/200/002",
                ItemDescription = "PackageName",
                QuantityUnit = 1,
                Price = 16314.67,
                Vat = 2284,
                Total = 18598.72
            });

            var data = new RootObject()
            {
                template = new Template() {shortid = "N190datG"},
                data = new Data()
                {
                    customer = new Customer()
                    {
                        name = "Customer 1",
                        taxRegistration = 4190195679,
                        packages = packagesList
                    }
                }
            };


            var report = new ReportMessage()
            {
                Id = Guid.NewGuid(),
                //reportBody = JsonConvert.SerializeObject(data);
            };

            bus.SendDynamic(report);
        }

        [Observation]
        public void it_should_publish_a_transaction()
        {
            _bus.ShouldNotBeNull();
        }
    }

    public class Template
    {
        public string shortid { get; set; }
    }

    public class Package
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int QuantityUnit { get; set; }
        public double Price { get; set; }
        public int Vat { get; set; }
        public double Total { get; set; }
    }

    public class Customer
    {
        public string name { get; set; }
        public long taxRegistration { get; set; }
        public List<Package> packages { get; set; }
    }

    public class Data
    {
        public Customer customer { get; set; }
    }

    public class RootObject
    {
        public Template template { get; set; }
        public Data data { get; set; }
    }
}