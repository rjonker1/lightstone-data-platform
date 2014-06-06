using System.Net;
using Billing.Api.Connector;
using Billing.Api.Dtos;
using Billing.Api.Tests.Fakes;
using DataPlatform.Shared.Public.Identifiers;
using Moq;
using RestSharp;
using Xunit.Extensions;

namespace Billing.Api.Tests.Connectors
{
    public class when_pinging_the_billing_api : Specification
    {
        private readonly IConnectToBilling connector;
        private readonly Mock<IRestClient> client;
        private readonly PingRequest request;
        private BillingConnectorResponse response;

        public when_pinging_the_billing_api()
        {
            client = new Mock<IRestClient>();
            client.Setup(c => c.Execute(It.IsAny<IRestRequest>())).Returns(new RestResponse()
            {
                StatusCode = HttpStatusCode.OK
            });

            connector = new DefaultBillingConnector(new TestBillingConnectorConfiguration(), client.Object);
            request = new PingRequest(new SystemIdentifier("TEST"));
        }

        public override void Observe()
        {
            response = connector.Ping(request);
        }

        [Observation]
        public void the_response_is_not_null()
        {
            response.ShouldNotBeNull();
        }

        [Observation]
        public void the_response_indicates_success()
        {
            response.Success.ShouldBeTrue();
        }

    }
}