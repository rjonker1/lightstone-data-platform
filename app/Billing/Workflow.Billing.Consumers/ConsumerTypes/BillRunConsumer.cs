using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Helpers;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Newtonsoft.Json;
using Workflow.Billing.Domain.Entities;
using Workflow.Reporting.Dtos;
using Workflow.Reporting.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IRepository<PreBilling> _preBillingrRepository;
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;

        private readonly IAdvancedBus _bus;

        public BillRunConsumer(IRepository<PreBilling> preBillingrRepository, IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository, IAdvancedBus bus)
        {
            _preBillingrRepository = preBillingrRepository;
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
            _bus = bus;
        }

        public void Consume(IMessage<BillingMessage> message)
        {

            var bus = new TransactionBus(_bus);

            var stageEntity = new StageBilling();
            var finalEntity =  new FinalBilling();

            foreach (var preBilling in _preBillingrRepository)
            {
                stageEntity = Mapper.Map(preBilling, new StageBilling());
                finalEntity = Mapper.Map(preBilling, new FinalBilling());
            }

            //StageBilling
            if (message.Body.RunType == "Stage")
                if (!_stageBillingRepository.Any(x => x.PreBillingId == stageEntity.PreBillingId)) _stageBillingRepository.SaveOrUpdate(stageEntity);

            //FinalBilling
            if (message.Body.RunType == "Final")
            {

                if (!_finalBillingRepository.Any(x => x.PreBillingId == finalEntity.PreBillingId)) _finalBillingRepository.SaveOrUpdate(finalEntity);

                var reportList = new List<ReportDto>();

                foreach (var transaction in _finalBillingRepository)
                {

                    var packagesList = _finalBillingRepository.Where(x => x.CustomerId == transaction.CustomerId)
                        .Select(x => new ReportPackage
                        {
                            ItemCode = "1000/200/002",
                            ItemDescription = x.PackageName,
                            QuantityUnit = 1,
                            Price = 16314.67,
                            Vat = 2284,
                            Total = 18598.72
                        }).Distinct();

                    var reportData = new ReportDto()
                    {
                        Template = new ReportTemplate {ShortId = "VJGAd9OM"},
                        Data = new ReportData
                        {
                            Customer = new ReportCustomer
                            {
                                Name = transaction.CustomerName,
                                TaxRegistration = 4190195679,
                                Packages = packagesList.ToList()
                            }
                        }
                    };

                    //Report Index
                    var reportIndex = reportList.FindIndex(x => x.Data.Customer.Name == transaction.CustomerName);

                    //Index restriction for new record
                    if (reportIndex < 0) reportList.Add(reportData);
                }

                foreach (var report in reportList)
                {

                    bus.SendDynamic(new ReportMessage
                    {
                        Id = Guid.NewGuid(),
                        ReportBody = JsonConvert.SerializeObject(report)
                    });
                }
               
            }
        }
    }
}