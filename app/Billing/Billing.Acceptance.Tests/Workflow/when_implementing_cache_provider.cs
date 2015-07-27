﻿using System;
using Billing.TestHelper.BaseTests;
using Workflow.Billing.Domain.Entities;
using Workflow.Billing.Repository;
using Xunit.Extensions;

namespace Billing.Acceptance.Tests.Workflow
{
    public class when_implementing_cache_provider : BaseTestHelper
    {
        private ICacheProvider<PreBilling> _preBillingCacheProvider;
        private ICacheProvider<StageBilling> _stageBillingCacheProvider;
        private ICacheProvider<FinalBilling> _finalBillingCacheProvider;

        private PreBilling _preBilling;
        private StageBilling _stageBilling;
        private FinalBilling _finalBilling;

        public override void Observe()
        {
            _preBillingCacheProvider = Container.Resolve<ICacheProvider<PreBilling>>();
            _stageBillingCacheProvider = Container.Resolve<ICacheProvider<StageBilling>>();
            _finalBillingCacheProvider = Container.Resolve<ICacheProvider<FinalBilling>>();

            _preBilling = new PreBilling { Id = Guid.NewGuid() };
            _stageBilling = new StageBilling { Id = Guid.NewGuid() };
            _finalBilling = new FinalBilling { Id = Guid.NewGuid() };
        }

        [Observation]
        public void should_persist_preBilling_record_to_redis_cache()
        {
            _preBillingCacheProvider.CacheClient.Store(_preBilling);
            _preBillingCacheProvider.CacheClient.GetById(_preBilling.Id).ShouldNotBeNull();

            _preBillingCacheProvider.CacheClient.DeleteById(_preBilling.Id);
            _preBillingCacheProvider.CacheClient.GetById(_preBilling.Id).ShouldBeNull();
        }
        
        [Observation]
        public void should_persist_stageBilling_record_to_redis_cache()
        {
            _stageBillingCacheProvider.CacheClient.Store(_stageBilling);
            _stageBillingCacheProvider.CacheClient.GetById(_stageBilling.Id).ShouldNotBeNull();

            _stageBillingCacheProvider.CacheClient.DeleteById(_stageBilling.Id);
            _stageBillingCacheProvider.CacheClient.GetById(_stageBilling.Id).ShouldBeNull();
        }
        
        [Observation]
        public void should_persist_finalBilling_record_to_redis_cache()
        {
            _finalBillingCacheProvider.CacheClient.Store(_finalBilling);
            _finalBillingCacheProvider.CacheClient.GetById(_finalBilling.Id).ShouldNotBeNull();

            _finalBillingCacheProvider.CacheClient.DeleteById(_finalBilling.Id);
            _finalBillingCacheProvider.CacheClient.GetById(_finalBilling.Id).ShouldBeNull();
        }
    }
}