using System;
using AutoMapper;
using BuildingBlocks.Configuration;
using Common.Logging;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Shared.BuildingBlocks.Api.Security;
using StackExchange.Redis;

namespace UmApi
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            // Perform registation that should have an application lifetime

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HashEntry, ApiUser>()
                    .ForMember(id => id.UserName, opt => opt.MapFrom(entry => (entry.Name + "").ToLower() == "username" ? entry.Value + "" : null));
            });

            var appSettings = new AppSettings();
            try
            {
                container.Register(ConnectionMultiplexer.Connect(appSettings.UmApi.RedisServers));
            }
            catch (Exception exception)
            {
                container.Register((ConnectionMultiplexer) null);
                _log.ErrorFormat("Error connecting to Redis server {0}", exception, appSettings.UmApi.RedisServers);
            }

            container.Register<IAuthenticateUser, RedisAuthenticator>();
            container.Register<IUmAuthenticator, UmAuthenticator>();
        }

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }
    }
}