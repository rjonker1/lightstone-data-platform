using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Workflow.Billing.Domain.Entities;
using Shared.BuildingBlocks.Api.Security;
using Workflow.Billing.Repository;


namespace Billing.Api.Modules
{
    public class AdminBillingModule : SecureModule
    {
        public AdminBillingModule(IRepository<AuditLog> auditLogs,
                                    IRepository<PreBilling> preBillingRepository,
                                    IRepository<StageBilling> stageBillingRepository,
                                    IRepository<FinalBilling> finalBillingRepository,
                                    ICacheProvider<PreBilling> preBillingCacheProvider,
                                    ICacheProvider<StageBilling> stageBillingCacheProvider,
                                    ICacheProvider<FinalBilling> finalBillingCacheProvider )
        {

            Get["/Admin/Billing"] = _ =>  Negotiate.WithView("Index");
            Get["/Admin/AuditLog"] = _ =>
            {
                return Negotiate
                    .WithView("AuditLog")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = auditLogs });
            };

            Post["/Admin/Cache/Flush/{cycle}"] = param =>
            {
                string billingCycle = param.billingCycle;

                switch (billingCycle)
                {
                    case "preBilling":
                        preBillingCacheProvider.FlushCacheProvider(preBillingCacheProvider);
                        break;

                    case "stageBilling":
                        stageBillingCacheProvider.FlushCacheProvider(stageBillingCacheProvider);
                        break;

                    case "finalBilling":
                        finalBillingCacheProvider.FlushCacheProvider(finalBillingCacheProvider);
                        break;
                }

                return Response.AsJson(new { data = "Success"});
            };

            Post["/Admin/Cache/Reload/{cycle}"] = param =>
            {
                string billingCycle = param.billingCycle;

                switch (billingCycle)
                {
                    case "preBilling":
                        preBillingCacheProvider.CachePipelineInsert(preBillingRepository);
                        break;

                    case "stageBilling":
                        stageBillingCacheProvider.CachePipelineInsert(stageBillingRepository);
                        break;

                    case "finalBilling":
                        finalBillingCacheProvider.CachePipelineInsert(finalBillingRepository);
                        break;
                }

                return Response.AsJson(new { data = "Success" });
            };
        }
    }
}