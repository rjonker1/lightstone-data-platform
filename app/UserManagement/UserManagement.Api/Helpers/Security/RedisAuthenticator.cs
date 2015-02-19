using System;
using System.Linq;
using AutoMapper;
using Common.Logging;
using Nancy.Security;
using Shared.BuildingBlocks.Api.Security;
using StackExchange.Redis;

namespace UserManagement.Api.Helpers.Security
{
    public class RedisAuthenticator : IRedisAuthenticator
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly ConnectionMultiplexer _redis;
        private readonly IUmAuthenticator _umAuthenticator;

        public RedisAuthenticator(ConnectionMultiplexer redis, IUmAuthenticator umAuthenticator)
        {
            _redis = redis;
            _umAuthenticator = umAuthenticator;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            IUserIdentity user;

            try
            {
                if (_redis == null)
                    return _umAuthenticator.GetUserIdentity(token); 
                
                var db = _redis.GetDatabase();
                var hashEntries = db.HashGetAll(token);
                user = Mapper.Map<HashEntry[], ApiUser>(hashEntries);

                if (!hashEntries.Any())
                {
                    user = _umAuthenticator.GetUserIdentity(token);
                    if (user != null) 
                        db.HashSet(token, new[] { new HashEntry("UserName", user.UserName), new HashEntry("Claims", user.Claims.Aggregate((current, next) => current + "|" + next)) });
                }
            }
            catch (Exception exception)
            {
                _log.ErrorFormat("Error getting ApiUser from Redis {0} for token {1}", exception, _redis.Configuration, token);
                return null;
            }

            return user;
        }
    }
}