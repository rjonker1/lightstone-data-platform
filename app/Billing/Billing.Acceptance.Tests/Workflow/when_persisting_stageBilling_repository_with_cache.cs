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
    public class when_persisting_stageBilling_repository_with_cache : BaseTestHelper
    {
        private IRepository<StageBilling> _stageBillingRepository;
        private ICacheProvider<StageBilling> _stageBillingCacheProvider;
        private IRedisTypedClient<StageBilling> _stageBillingClient;

        private StageBilling _stageBilling;

        public override void Observe()
        {
            _stageBillingRepository = Container.Resolve<IRepository<StageBilling>>();
            _stageBillingCacheProvider = Container.Resolve<ICacheProvider<StageBilling>>();

            _stageBillingClient = _stageBillingCacheProvider.CacheClient;

            _stageBilling = new StageBilling { Id = Guid.NewGuid() };
        }

        [Observation]
        public void should_persist_stageBilling_record_with_cache()
        {
            var stageSave = _stageBillingClient.GetAll();

            _stageBillingRepository.SaveOrUpdate(_stageBilling, true);

            var postSave = _stageBillingClient.GetAll();

            postSave.Count.ShouldEqual(stageSave.Count + 1);

            _stageBillingClient.DeleteById(_stageBilling.Id);
            _stageBillingClient.GetById(_stageBilling.Id).ShouldBeNull();
        }

        [Observation]
        public void should_load_stageBilling_into_cache_if_any_records()
        {
            _stageBillingClient.DeleteAll();

            var preDBCache = _stageBillingClient.GetAll();

            if (_stageBillingRepository.Any())
            {
                _stageBillingCacheProvider.CachePipelineInsert(_stageBillingRepository);

                var postDBCache = _stageBillingClient.GetAll();

                Assert.True(postDBCache.Count > preDBCache.Count);

                _stageBillingClient.DeleteAll();
                _stageBillingClient.GetAll().ShouldBeEmpty();
            }
        }
    }
}