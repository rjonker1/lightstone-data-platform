using System;
using System.Linq;
using Billing.TestHelper.BaseTests;
using DataPlatform.Shared.Repositories;
using ServiceStack.Redis.Generic;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Workflow
{
    public class when_persisting_finalBilling_repository_with_cache : BaseTestHelper
    {
        private IRepository<FinalBilling> _finalBillingRepository;
        private ICacheProvider<FinalBilling> _finalBillingCacheProvider;
        private IRedisTypedClient<FinalBilling> _finalBillingClient;

        private FinalBilling _finalBilling;

        public override void Observe()
        {
            _finalBillingRepository = Container.Resolve<IRepository<FinalBilling>>();
            _finalBillingCacheProvider = Container.Resolve<ICacheProvider<FinalBilling>>();

            _finalBillingClient = _finalBillingCacheProvider.CacheClient;

            _finalBilling = new FinalBilling { Id = Guid.NewGuid() };
        }

        [Observation]
        public void should_persist_finalBilling_record_with_cache()
        {
            var finalSave = _finalBillingClient.GetAll();

            _finalBillingRepository.SaveOrUpdate(_finalBilling);

            var postSave = _finalBillingClient.GetAll();

            postSave.Count.ShouldEqual(finalSave.Count + 1);

            _finalBillingClient.DeleteById(_finalBilling.Id);
            _finalBillingClient.GetById(_finalBilling.Id).ShouldBeNull();
        }

        [Observation]
        public void should_load_finalBilling_into_cache_if_any_records()
        {
            _finalBillingClient.DeleteAll();

            var preDBCache = _finalBillingClient.GetAll();

            if (_finalBillingRepository.Any())
            {
                _finalBillingCacheProvider.CachePipelineInsert(_finalBillingRepository);

                var postDBCache = _finalBillingClient.GetAll();

                Assert.True(postDBCache.Count > preDBCache.Count);

                _finalBillingClient.DeleteAll();
                _finalBillingClient.GetAll().ShouldBeEmpty();
            }
        }
    }
}