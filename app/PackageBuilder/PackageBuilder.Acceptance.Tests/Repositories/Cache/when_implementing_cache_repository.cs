using System;
using System.Configuration;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Write;
using PackageBuilder.TestHelper.BaseTests;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.Cache
{
    public class when_implementing_cache_repository : MemoryTestDataBaseHelper
    {
        private readonly string _host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;

        private RedisClient _redisClient;
        private Package _package;

        private IRedisTypedClient<Package> _packageClient;
        private INEventStoreRepository<Package> _writeRepository; 

        public override void Observe()
        {
            RefreshDb();

            _redisClient = new RedisClient(_host);
            _packageClient = _redisClient.As<Package>();

            _package = new Package {Id = Guid.NewGuid()};

            _writeRepository = Container.Resolve<INEventStoreRepository<Package>>();
        }

        [Observation]
        public void should_persist_to_redis_cache()
        {
            _packageClient.Store(_package);
            _packageClient.GetById(_package.Id).ShouldNotBeNull();

            should_remove_from_redis_cache();
        }

        [Observation]
        public void should_persist_through_implementation()
        {
            var preCache = _packageClient.GetAll();

            _writeRepository.Save(_package, Guid.NewGuid(), true);

            var postCache = _packageClient.GetAll();
            postCache.Count.ShouldEqual(preCache.Count + 1);

           should_remove_from_redis_cache();
        }

        [Observation]
        public void should_remove_from_redis_cache()
        {
            _packageClient.DeleteById(_package.Id);
            _packageClient.GetById(_package.Id).ShouldBeNull();
        }
    }
}