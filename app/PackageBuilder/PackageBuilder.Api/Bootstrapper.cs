using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using CommonDomain.Persistence;
using DataPlatform.Shared.Repositories;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using PackageBuilder.Api.Modules;
using PackageBuilder.Domain.DataFields;
using PackageBuilder.Domain.DataProviders;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;
using Raven.Client;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api
{
    public class Bootstrapper : WindsorNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            //pipelines.EnableStatelessAuthentication(container.Resolve<IAuthenticateUser>());
            pipelines.EnableCors(); // cross origin resource sharing

      
            //NHibernateBootstrapper.Build();
            //Make every request SSL based
			//pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            // Perform registation that should have an application lifetime
            base.ConfigureApplicationContainer(container);

            Domain.Bootstrapper.Startup(container);

            container.Register(Component.For<IAuthenticateUser>().ImplementedBy<UmApiAuthenticator>());
            //container.Register(Component.For<IPackageLookupRepository>().Instance(PackageLookupMother.GetCannedVersion())); // Canned test data (sliver implementation)
            
        }

        protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            pipelines.AfterRequest.AddItemToEndOfPipeline(ctx =>
            {
                var documentSession = container.Resolve<IDocumentSession>();
                if (ctx.Response.StatusCode != HttpStatusCode.InternalServerError)
                    documentSession.SaveChanges();

                documentSession.Dispose();
            });
        }

        //static void AllowAccessToConsumingSite(IPipelines pipelines)
        //{
            
        //    pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
        //    {
                
        //        x.Response.Headers.Add("Access=Control-Allow-Origin", "*");
        //        x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,DELETE,PUT,OPTIONS");

        //    });
        //}

        
    }
}