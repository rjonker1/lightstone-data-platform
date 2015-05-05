using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages.BillingRun;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
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

            foreach (var preBilling in _preBillingrRepository)
            {
                var stageEntity = Mapper.Map(preBilling, new StageBilling());
                var finalEntity = Mapper.Map(preBilling, new FinalBilling());

                if (message.Body.RunType == "Stage") 
                    if (!_stageBillingRepository.Any(x => x.PreBillingId == stageEntity.PreBillingId)) _stageBillingRepository.SaveOrUpdate(stageEntity);

                if (message.Body.RunType == "Final")
                    if (!_finalBillingRepository.Any(x => x.PreBillingId == finalEntity.PreBillingId)) _finalBillingRepository.SaveOrUpdate(finalEntity);
            }
        }
    }
}