using System.Threading.Tasks;
using DataPlatform.Shared.Helpers.Extensions;
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

        public async Task Consume(IMessage<BillCacheMessage> message)
        {
            switch (message.Body.BillingType.Name)
            {
                case "PreBilling":
                    _preBillingCacheProvider.Initialize();

                    this.Info(() => "Processing PreBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) await _preBillingCacheProvider.CachePipelineInsert(_preBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _preBillingCacheProvider.FlushCacheProvider(_preBillingCacheProvider);
                    this.Info(() => "Completed PreBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    break;

                case "StageBilling":
                    _stageBillingCacheProvider.Initialize();

                    this.Info(() => "Processing StageBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) await _stageBillingCacheProvider.CachePipelineInsert(_stageBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _stageBillingCacheProvider.FlushCacheProvider(_stageBillingCacheProvider);
                    this.Info(() => "Completed StageBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    break;

                case "FinalBilling":
                    _finalBillingCacheProvider.Initialize();

                    this.Info(() => "Processing FinalBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    if (message.Body.Command.Equals(BillingCacheCommand.Reload)) await _finalBillingCacheProvider.CachePipelineInsert(_finalBillingRepository);
                    if (message.Body.Command.Equals(BillingCacheCommand.Flush)) _finalBillingCacheProvider.FlushCacheProvider(_finalBillingCacheProvider);
                    this.Info(() => "Completed FinalBilling - {0}".FormatWith(message.Body.Command.ToString()));
                    break;
            }
        }
    }
}