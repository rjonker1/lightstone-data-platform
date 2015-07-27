using System;
using ServiceStack.Redis.Generic;

namespace Workflow.Billing.Repository
{
    public interface ICacheProvider<T> : ICacheRepository<T> 
    {
        IRedisTypedClient<T> CacheClient { get; set; }
    }
}