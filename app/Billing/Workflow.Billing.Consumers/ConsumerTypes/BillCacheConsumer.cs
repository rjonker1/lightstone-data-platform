using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Messages.Publishable;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumers.ConsumerTypes
{
    public class BillCacheConsumer
    {
        private readonly ICacheProvider<PreBilling> _preBillingCacheProvider; 
        private readonly ICacheProvider<StageBilling> _stageBillingCacheProvider; 
        private readonly ICacheProvider<FinalBilling> _finalBillingCacheProvider;

        private readonly IRepository<PreBilling> _preBillingRepository; 
        private readonly IRepository<StageBilling> _stageBillingRepository; 
        private readonly IRepository<FinalBilling> _finalBillingRepository; 

        public BillCacheConsumer(ICacheProvider<PreBilling> preBillingCacheProvider, ICacheProvider<StageBilling> stageBillingCacheProvider, ICacheProvider<FinalBilling> finalBillingCacheProvider, 
                                    IRepository<PreBilling> preBillingRepository,
                                    IRepository<StageBilling> stageBillingRepository,
                                    IRepository<FinalBilling> finalBillingRepository)
        {
            _preBillingCacheProvider = preBillingCacheProvider;
            _stageBillingCacheProvider = stageBillingCacheProvider;
            _finalBillingCacheProvider = finalBillingCacheProvider;

            _preBillingRepository = preBillingRepository;
            _stageBillingRepository = stageBillingRepository;
            _finalBillingRepository = finalBillingRepository;
        }

        public void Consume(IMessage<BillCacheMessage> message)
        {
            switch (message.Body.BillingType.Name)
            {
                case "PreBilling":
                    _preBillingCacheProvider.Initialize();

                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) _preBillingCacheProvider.CachePipelineInsert(_preBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _preBillingCacheProvider.FlushCacheProvider(_preBillingCacheProvider);
                    break;

                case "StageBilling":
                    _stageBillingCacheProvider.Initialize();
                    
                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) _stageBillingCacheProvider.CachePipelineInsert(_stageBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _stageBillingCacheProvider.FlushCacheProvider(_stageBillingCacheProvider);
                    break;

                case "FinalBilling":
                    _finalBillingCacheProvider.Initialize();
                    
                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) _finalBillingCacheProvider.CachePipelineInsert(_finalBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _finalBillingCacheProvider.FlushCacheProvider(_finalBillingCacheProvider);
                    break;
            }
        }
    }
}