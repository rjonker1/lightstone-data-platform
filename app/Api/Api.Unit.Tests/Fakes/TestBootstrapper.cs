using System.Collections.Generic;
using System.Linq;
using Api.Domain.Infrastructure.Automapping;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Handlers;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;
using Api.Domain.Verification.Infrastructure.Services;
using Api.Tests.Helper.Builder;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;
using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Fakes
{
    public class TestBootstrapper : Bootstrapper
    {
        private readonly string _username;

        public TestBootstrapper(string username)
        {
            _username = username;
        }

        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            AutoMapperConfiguration.Init();
            container.Register(Component.For<IAuthenticateUser>().Instance(new TestAuthenticator(_username)));
            container.Register(Component.For<IEntryPoint>().Instance(new FakeEntryPoint()));
            container.Register(Component.For<IConnectToBilling>().Instance(new FakeConnectToBilling()));

            container.Register(Component.For<ICallFicaVerification>().ImplementedBy<FicaVerificationService>());
            container.Register(Component.For<IHandleFicaVerficationRequests>().ImplementedBy<FicaVerificationHandler>());

            container.Register(Component.For<ICallDriversLicenseVerification>().ImplementedBy<DriversLicenseVerificationService>());
            container.Register(Component.For<IHandleDriversLicenseVerficationRequests>().ImplementedBy<DriversLicenseVerificationHandler>());
        }
    }

    public class FakeEntryPoint : IEntryPoint
    {
        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ILaceRequest request)
        {
            return
                new FakeDataProviderResults().LaceResponse.FirstOrDefault(w => w.Key == request.Package.Action.Name)
                    .Value;
        }
    }

    public class FakeConnectToBilling : IConnectToBilling
    {
        public BillingConnectorResponse Ping(PingRequest request)
        {
            return null;
        }

        public BillingConnectorResponse CreateTransaction(CreateTransaction transaction)
        {
            return null;
        }

        public GetTransactionResponse GetTransaction(GetTransactionRequest request)
        {
            return null;
        }
    }
}