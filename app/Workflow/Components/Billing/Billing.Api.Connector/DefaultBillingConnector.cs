using System;
using System.Net;
using System.Security.Policy;
using Billing.Api.Connector.Configuration;
using Billing.Api.Dtos;
using Common.Logging;
using RestSharp;

namespace Billing.Api.Connector
{
    public class DefaultBillingConnector : IConnectToBilling
    {
        private static readonly ILog log = LogManager.GetLogger<DefaultBillingConnector>();
        private readonly IRestClient client;
        private readonly IBillingConnectorConfiguration configuration;
        private readonly BillingUrlBuilder urlBuilder;

        public DefaultBillingConnector(IBillingConnectorConfiguration configuration) : this(configuration, new RestClient(configuration.Url))
        {
        }

        public DefaultBillingConnector(IBillingConnectorConfiguration configuration, IRestClient client)
        {
            this.configuration = configuration;
            urlBuilder = new BillingUrlBuilder(configuration);
            this.client = client;
        }

        public BillingConnectorResponse Ping(PingRequest request)
        {
            log.InfoFormat("Pinging the billing API at {0} with segment {1}", configuration.Url, urlBuilder.PingSegment());

            var response = PostApi(urlBuilder.PingSegment(), new RestRequest(urlBuilder.PingSegment()));

            log.InfoFormat("Pinging the billing API at {0} completed. The response was {1}", configuration.Url, response);

            return response;
        }

        private BillingConnectorResponse PostApi(string segment, IRestRequest request)
        {
            try
            {
                log.InfoFormat("Invoking billing API on {0} with segment {1}", configuration.Url, segment);

                request.AddHeader("apikey", configuration.ApiKey);

                var response = client.Post(request);

                if (response.StatusCode == HttpStatusCode.OK)
                    return new BillingConnectorResponse(true);

                var failureMessage =
                    string.Format(
                        "Call to billing API return non OK status code. The status code was {0}. The response status code was {1}. The error description is {2}",
                        response.StatusCode, response.ResponseStatus, response.ErrorMessage);

                log.ErrorFormat(failureMessage);
            }
            catch (Exception e)
            {
                log.ErrorFormat("Failed to invoke billing API on {0} because {1}", configuration.Url, e);
            }
            return new BillingConnectorResponse(false);
        }
    }
}