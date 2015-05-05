using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Newtonsoft.Json;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillRunConsumer
    {
        private readonly IRepository<PreBilling> _preBillingrRepository; 
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<FinalBilling> _finalBillingRepository;

        public BillRunConsumer(IRepository<PreBilling> preBillingrRepository, IRepository<StageBilling> stageBillingRepository, IRepository<FinalBilling> finalBillingRepository)
        {
            _preBillingrRepository = preBillingrRepository;
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
        }

        public void Consume(IMessage<BillingMessage> message)
        {
            var stageEntity = new StageBilling();
            var finalEntity =  new FinalBilling();

            foreach (var preBilling in _preBillingrRepository)
            {
                stageEntity = Mapper.Map(preBilling, new StageBilling());
                finalEntity = Mapper.Map(preBilling, new FinalBilling());
            }

            if (message.Body.RunType == "Stage")
                if (!_stageBillingRepository.Any(x => x.PreBillingId == stageEntity.PreBillingId)) _stageBillingRepository.SaveOrUpdate(stageEntity);

            if (message.Body.RunType == "Final")
            {
                if (!_finalBillingRepository.Any(x => x.PreBillingId == finalEntity.PreBillingId)) _finalBillingRepository.SaveOrUpdate(finalEntity);

                //var packagesList = new List<ReportPackage>();
                //packagesList.Add(new ReportPackage
                //{
                //    ItemCode = "1000/200/002",
                //    ItemDescription = "PackageName",
                //    QuantityUnit = 1,
                //    Price = 16314.67,
                //    Vat = 2284,
                //    Total = 18598.72
                //});

                //var data = new ReportDto
                //{
                //    Template = new ReportTemplate { ShortId = "VJGAd9OM" },
                //    Data = new ReportData
                //    {
                //        Customer = new ReportCustomer
                //        {
                //            Name = "Customer 1",
                //            TaxRegistration = 4190195679,
                //            Packages = packagesList
                //        }
                //    }
                //};


                //var report = new ReportMessage()
                //{
                //    Id = Guid.NewGuid(),
                //    ReportBody = JsonConvert.SerializeObject(data)
                //};
            }
        }
    }
}