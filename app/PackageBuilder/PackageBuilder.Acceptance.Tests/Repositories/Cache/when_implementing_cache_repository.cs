using System;
using System.Configuration;
using PackageBuilder.Domain.Entities.Packages.Write;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Repositories.Cache
{
    public class when_implementing_cache_repository : Specification
    {
        private static readonly string host = ConfigurationManager.ConnectionStrings["workflow/redis/cache"].ConnectionString;

        private static RedisClient _redisClient = new RedisClient(host);
        private readonly IRedisTypedClient<Package> packageClient = _redisClient.As<Package>();


        private readonly Package package = new Package();

        public override void Observe()
        {
            package.Id = Guid.NewGuid();
        }

        [Observation]
        public void should_persist_to_cache()
        {
            packageClient.Store(package);
            packageClient.GetById(package.Id).ShouldNotBeNull();
        }

        [Observation]
        public void should_remove_from_cache()
        {
            packageClient.Delete(package);
            packageClient.GetById(package.Id).ShouldBeNull();
        }
    }
}