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
        }

        [Observation]
        public void should_remove_from_redis_cache()
        {
            packageClient.Delete(package);
            packageClient.GetById(package.Id).ShouldBeNull();
        }

        [Observation]
        public void should_persist_through_implementation()
        {
            var preCache = packageClient.GetAll();

            WriteRepository.CacheSave(package);

            //WriteRepository.CacheSave(WritePackageMother.EzScorePackage);
            //WriteRepository.CacheSave(WritePackageMother.FicaVerificationPackage);
            //WriteRepository.CacheSave(WritePackageMother.FullVerificationPackage);
            //WriteRepository.CacheSave(WritePackageMother.LicensePlateSearchPackage);
            //WriteRepository.CacheSave(WritePackageMother.LicenseScanPackage);
            //WriteRepository.CacheSave(WritePackageMother.PartialVerificationPackage);
            //WriteRepository.CacheSave(WritePackageMother.PropertyPackage);

            var postCache = packageClient.GetAll();

            Assert.True(postCache.Count == preCache.Count + 1);

            //Clean-up
            WriteRepository.CacheDelete(package.Id);
            packageClient.GetById(package.Id).ShouldBeNull();
        }
    }
}