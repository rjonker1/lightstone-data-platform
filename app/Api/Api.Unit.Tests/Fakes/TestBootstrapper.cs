using System.Collections.Generic;
using Api.Infrastructure.Automapping;
//using Billing.Api.Connector;
//using Billing.Api.Dtos;
//using Lace.Domain.Core.Requests.Contracts;
//using Lace.Domain.Infrastructure.Core.Contracts;
//using Lace.Domain.Infrastructure.Core.Dto;
using Nancy.TinyIoc;
//using Shared.BuildingBlocks.Api.Security;

namespace Api.Unit.Tests.Fakes
{
    //public class TestBootstrapper : Bootstrapper
    //{
    //    private readonly string _username = string.Empty;
    //    public TestBootstrapper(string username)
    //    {
    //        _username = username;
    //    }

    //    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    //    {
    //        AutoMapperConfiguration.Init();
    //        container.Register<IAuthenticateUser>(new TestAuthenticator(_username));
    //        container.Register<IEntryPoint>(new FakeEntryPoint());
    //        container.Register<IConnectToBilling>(new FakeConnectToBilling());
    //    }
    //}

    //public class FakeEntryPoint : IEntryPoint
    //{
    //    public IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class FakeConnectToBilling : IConnectToBilling
    //{
    //    public BillingConnectorResponse Ping(PingRequest request)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public BillingConnectorResponse CreateTransaction(CreateTransaction transaction)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public GetTransactionResponse GetTransaction(GetTransactionRequest request)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}