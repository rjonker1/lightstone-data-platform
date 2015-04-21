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

        public BillRunConsumer(IRepository<PreBilling> preBillingrRepository, IRepository<StageBilling> stageBillingRepository)
        {
            _preBillingrRepository = preBillingrRepository;
            _stageBillingRepository = stageBillingRepository;
        }

        public void Consume(IMessage<BillingMessage> message)
        {

            foreach (var preBilling in _preBillingrRepository)
            {
                var entity = Mapper.Map(preBilling, new StageBilling());

                if (!_stageBillingRepository.Any(x => x.PreBillingId == entity.PreBillingId)) _stageBillingRepository.SaveOrUpdate(entity);
            }
        }
    }
}