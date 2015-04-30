using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class CallIvidDataProvider : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _response;
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;

        public CallIvidDataProvider(IAmDataProvider dataProvider, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                GetResponse();
                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Data Provider {0}", ex.Message);
                _logComand.LogFault(ex.Message, new { ErrorMessage = "Error calling Ivid Data Provider" });
                IvidResponseFailed(response);
            }
        }

        private DataProviderState CheckState()
        {
            return _response == null
                ? DataProviderState.Failed
                : _response.partialResponse ? DataProviderState.PartialFailure : DataProviderState.Successful;
        }

        private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }

        private void GetResponse()
        {
            var webService = new ConfigureIvid();

            _logComand.LogSecurity(
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

                var request =
                    new IvidRequestMessage(_dataProvider.GetRequest<IAmIvidStandardRequest>())
                        .HpiQueryRequest;

                _logComand.LogConfiguration(request, null);
                _logComand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                    .ForWebApiType(), request);

                _response = webService
                    .Client
                    .HpiStandardQuery(request);

                webService.CloseWebService();

                _logComand.LogResponse(CheckState(),
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _response ?? new HpiStandardQueryResponse());

                if (_response == null)
                    _logComand.LogFault(_dataProvider,
                        new {NoRequestReceived = "No response received from Ivid Data Provider"});
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logComand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
