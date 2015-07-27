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
    public class when_persiting_preBilling_repository_with_cache : BaseTestHelper
    {
        private IRepository<PreBilling> _preBillingRepository;
        private ICacheProvider<PreBilling> _preBillingCacheProvider;
        private IRedisTypedClient<PreBilling> _preBillingClient;

        private PreBilling _preBilling;

        public override void Observe()
        {
            _preBillingRepository = Container.Resolve<IRepository<PreBilling>>();
            _preBillingCacheProvider = Container.Resolve<ICacheProvider<PreBilling>>();

            _preBillingClient = _preBillingCacheProvider.CacheClient;

            _preBilling = new PreBilling { Id = Guid.NewGuid() };
        }

        [Observation]
        public void should_persist_preBilling_record_with_cache()
        {
            var preSave = _preBillingClient.GetAll();

            _preBillingRepository.SaveOrUpdate(_preBilling);

            var postSave = _preBillingClient.GetAll();

            postSave.Count.ShouldEqual(preSave.Count + 1);

            _preBillingClient.DeleteById(_preBilling.Id);
            _preBillingClient.GetById(_preBilling.Id).ShouldBeNull();
        }

        [Observation]
        public void should_load_preBilling_into_cache_if_any_records()
        {
            _preBillingClient.DeleteAll();

            var preDBCache = _preBillingClient.GetAll();

            if (_preBillingRepository.Any())
            {
                _preBillingCacheProvider.CachePipelineInsert(_preBillingRepository);

                var postDBCache = _preBillingClient.GetAll();

                Assert.True(postDBCache.Count > preDBCache.Count);
            }

            _preBillingClient.DeleteAll();
            _preBillingClient.GetAll().ShouldBeEmpty();
        }
    }
}