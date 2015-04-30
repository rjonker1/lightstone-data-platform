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
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class CallIvidTitleHolderDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private TitleholderQueryResponse _response;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;

        public CallIvidTitleHolderDataProvider(IAmDataProvider dataProvider, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                GetResponse(response);
                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex.Message);
                _logComand.LogFault(new {ex.Message}, new {ErrorMessage = "Error calling Ivid Title Holder Data Provider"});
                IvidTitleHolderResponseFailed(response);
            }
        }

        private void GetResponse(ICollection<IPointToLaceProvider> response)
        {
            var webService = new ConfigureIvidTitleHolder();

            using (var scope = new OperationContextScope(webService.Client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                    webService.RequestMessageProperty;

                var request =
                    new IvidTitleHolderRequestMessage(_dataProvider.GetRequest<IAmIvidTitleholderRequest>(), response).TitleholderQueryRequest;

                _logComand.LogConfiguration(new {request}, null);
                _logComand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {request});

                _response = webService
                    .Client
                    .TitleholderQuery(request);

                webService.Close();

                _logComand.LogResponse(_response == null ? DataProviderState.Failed : DataProviderState.Successful,
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _response ?? new TitleholderQueryResponse());

                if (_response == null)
                    _logComand.LogFault(new {_dataProvider}, new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"});
            }
        }

        private static void IvidTitleHolderResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = new IvidTitleHolderResponse();
            ividTitleHolderResponse.HasBeenHandled();
            response.Add(ividTitleHolderResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidTitleHolderResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logComand.LogTransformation(new { transformer.Result }, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
