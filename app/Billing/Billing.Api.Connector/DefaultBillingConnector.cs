using System;
using System.Net;
using Billing.Api.Connector.Configuration;
using Billing.Api.Dtos;
using Common.Logging;
using RestSharp;

namespace Billing.Api.Connector
{
    public class DefaultBillingConnector : IConnectToBilling
    {
        private static readonly ILog log = LogManager.GetLogger<DefaultBillingConnector>();
        private readonly IRestClient _client;
        private readonly IBillingConnectorConfiguration _configuration;
        private readonly BillingUrlBuilder _urlBuilder;

        public DefaultBillingConnector(IBillingConnectorConfiguration configuration) : this(configuration, new RestClient(configuration.Url))
        {
        }

        public DefaultBillingConnector(IBillingConnectorConfiguration configuration, IRestClient client)
        {
            this._configuration = configuration;
            _urlBuilder = new BillingUrlBuilder(configuration);
            this._client = client;
        }

        public BillingConnectorResponse Ping(PingRequest request)
        {
            log.InfoFormat("Pinging the billing API at {0} with segment {1}", _configuration.Url, _urlBuilder.PingSegment());

            var response = PostApi(_urlBuilder.PingSegment(), new RestRequest(_urlBuilder.PingSegment()));

            log.InfoFormat("Pinging the billing API at {0} completed. The response was {1}", _configuration.Url, response);

            return response;
        }

        public BillingConnectorResponse CreateTransaction(CreateTransaction transaction)
        {
            log.InfoFormat("Creating a transaction via the billing API at {0} with segment {1}", _configuration.Url,
                _urlBuilder.CreateTransactionSegment());

            var postRequest = new RestRequest(_urlBuilder.CreateTransactionSegment())
            {
                RequestFormat = DataFormat.Json,
                
            };
            postRequest.AddHeader("Content-Type", "application/json");
            postRequest.AddBody(transaction);

            var response = PostApi(_urlBuilder.CreateTransactionSegment(), postRequest);

            log.InfoFormat("Creating a transaction via the billing API at {0} completed. The response was {1}", _configuration.Url, response);

            return response;
        }
        public GetTransactionResponse GetTransaction(GetTransactionRequest request)
        {
            log.InfoFormat("Getting a transaction from the billing API at {0} with segment {1}", _configuration.Url, _urlBuilder.GetTransactionSegment());

            var response = PostApi(_urlBuilder.GetTransactionSegment(), new RestRequest(_urlBuilder.GetTransactionSegment()));

            log.InfoFormat("Get of the transaction at {0} completed. The response was {1}", _configuration.Url, response);

            return null;
        }

        private BillingConnectorResponse PostApi(string segment, IRestRequest request)
        {
            try
            {
                log.InfoFormat("Invoking billing API on {0} with segment {1}", _configuration.Url, segment);

                request.AddHeader("apikey", _configuration.ApiKey);

                var response = _client.Post(request);

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
                log.ErrorFormat("Failed to invoke billing API on {0} because {1}", _configuration.Url, e);
            }
            return new BillingConnectorResponse(false);
        }
    }
}