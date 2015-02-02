using System.Linq;
using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;
using Api.Scans.Verfication.Infrastructure.Handlers;
using Api.Scans.Verfication.Infrastructure.Services;
using Nancy;
using Nancy.Authentication.Stateless;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Api.Scans.Verfication
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            var handler = new UserManagementRequestHandler(new UserManagementService());

            var configuration = new StatelessAuthenticationConfiguration(c =>
            {
                var authToken = (string) c.Request.Headers["AuthToken"].FirstOrDefault();
                handler.Handle(new AuthenticateUserFromTokenCommand(new AuthenticatedUserIdentityRequestDto(authToken)));
                return handler.UserIdentity.UserIdentity;
            });

            AllowAccessToConsumingSite(pipelines);
            StatelessAuthentication.Enable(pipelines,configuration);
        }

        private static void AllowAccessToConsumingSite(IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x =>
            {
                x.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                x.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET");
            });
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ICallUserManagement, UserManagementService>();
            container.Register<IHandleUserManagementRequests, UserManagementRequestHandler>();

            container.Register<ICallFicaVerification, FicaVerificationService>();
            container.Register<IHandleFicaVerficationRequests, FicaVerificationHandler>();

            container.Register<ICallDriversLicenseVerification, DriversLicenseVerificationService>();
            container.Register<IHandleDriversLicenseVerficationRequests, DriversLicenseVerificationHandler>();
        }
    }
}