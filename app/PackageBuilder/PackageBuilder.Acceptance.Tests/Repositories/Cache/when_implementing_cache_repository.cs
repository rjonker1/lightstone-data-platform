using System;
using System.Configuration;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.Unit.Tests.Installers;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.Cache
{
    public class when_implementing_cache_repository : when_installing_nventstore_dependency
    {
        private static readonly string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;

        private static RedisClient _redisClient;
        private static Package package;

        private static IRedisTypedClient<Package> packageClient;
        protected INEventStoreRepository<Package> WriteRepository; 

        public override void Observe()
        {
            base.Observe();

            _redisClient = new RedisClient(host);
            packageClient = _redisClient.As<Package>();

            package = new Package();
            package.Id = Guid.NewGuid();

            WriteRepository = _container.Resolve<INEventStoreRepository<Package>>();
        }

        [Observation]
        public void should_persist_to_redis_cache()
        {
            packageClient.Store(package);
            packageClient.GetById(package.Id).ShouldNotBeNull();

            should_remove_from_redis_cache();
        }

        [Observation]
        public void should_persist_through_implementation()
        {
            var preCache = packageClient.GetAll();

            WriteRepository.Save(package, Guid.NewGuid());

            var postCache = packageClient.GetAll();

            Assert.True(postCache.Count == preCache.Count + 1);

           should_remove_from_redis_cache();
        }

        [Observation]
        public void should_remove_from_redis_cache()
        {
            packageClient.DeleteById(package.Id);
            packageClient.GetById(package.Id).ShouldBeNull();
        }
    }
}