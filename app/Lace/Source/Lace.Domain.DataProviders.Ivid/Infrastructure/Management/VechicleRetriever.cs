using System.ServiceModel;
using System.ServiceModel.Channels;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.DataProvider.Repositories;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public class VechicleRetriever
    {
        private readonly ILogCommandTypes _logCommand;

        private VechicleRetriever(ILogCommandTypes logCommand)
        {
            _logCommand = logCommand;
        }

        public static VechicleRetriever Start(ILogCommandTypes logCommand)
        {
            return new VechicleRetriever(logCommand);
        }

        public VechicleRetriever FirstWithCache(HpiStandardQueryRequest request)
        {
            var parameter = GetCacheSearch(request);
            if (string.IsNullOrEmpty(parameter))
                return this;

            CacheResponse = DataProviderRepository.GetKeyFromCache<IvidResponse>(string.Format(IvidResponse.CacheKey, parameter));
            return this;
        }

        public VechicleRetriever ThenWithApi(HpiStandardQueryRequest request, IAmDataProvider dataProvider,
            out HpiStandardQueryResponse response)
        {
            if (NoNeedToCallApi)
            {
                response = null;
                return this;
            }

            var webService = new ConfigureIvid();

            _logCommand.LogSecurity(
                new
                {
                    Credentials =
                        new
                        {
                            webService.Client.ClientCredentials.UserName.UserName,
                            webService.Client.ClientCredentials.UserName.Password
                        }
                },
                new {ContextMessage = "Ivid Data Provider Credentials"});

            using (var scope = new OperationContextScope(webService.Client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    webService.RequestMessageProperty;

                _logCommand.LogConfiguration(request, null);
                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                    .ForWebApiType(), request);

                response = webService
                    .Client
                    .HpiStandardQuery(request);

                webService.CloseWebService();

                _logCommand.LogResponse(CheckState(response),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), response ?? new HpiStandardQueryResponse());

                if (response == null)
                    _logCommand.LogFault(dataProvider,
                        new {NoRequestReceived = "No response received from Ivid Data Provider"});
            }

            return this;
        }

        private DataProviderState CheckState(HpiStandardQueryResponse response)
        {
            return response == null
                ? DataProviderState.Failed
                : response.partialResponse ? DataProviderState.PartialFailure : DataProviderState.Successful;
        }

        private static string GetCacheSearch(HpiStandardQueryRequest request)
        {
            if (string.IsNullOrEmpty(request.VinOrChassis) && string.IsNullOrWhiteSpace(request.LicenceNo))
                return string.Empty;

            if (!string.IsNullOrEmpty(request.VinOrChassis))
                return request.VinOrChassis;

            if (!string.IsNullOrEmpty(request.LicenceNo))
                return request.LicenceNo;

            return !string.IsNullOrEmpty(request.RegisterNo) ? request.RegisterNo : string.Empty;
        }

        public IProvideDataFromIvid CacheResponse { get; private set; }
        public HpiStandardQueryResponse Response { get; private set; }
        public bool NoNeedToCallApi
        {
            get
            {
                return CacheResponse != null;
            }
        }
    }
}
