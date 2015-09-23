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
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public sealed class CallIvidTitleHolderDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private TitleholderQueryResponse _response;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public CallIvidTitleHolderDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
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
                _log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex,ex.Message);
                _logCommand.LogFault(new {ex}, new {ErrorMessage = "Error calling Ivid Title Holder Data Provider"});
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
                    HandleRequest.GetTitleholderQueryRequest(response,_dataProvider.GetRequest<IAmIvidTitleholderRequest>());

                _logCommand.LogConfiguration(new {request}, null);
                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new {request});

                _response = webService
                    .Client
                    .TitleholderQuery(request);

                webService.Close();

                _logCommand.LogResponse(_response == null ? DataProviderState.Failed : DataProviderState.Successful,
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _response ?? new TitleholderQueryResponse());

                if (_response == null)
                    _logCommand.LogFault(new {_dataProvider}, new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"});
            }
        }

        private void IvidTitleHolderResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = _dataProvider.IsCritical() ? IvidTitleHolderResponse.Failure(_dataProvider.Message()) : IvidTitleHolderResponse.Empty();
            ividTitleHolderResponse.HasBeenHandled();
            response.Add(ividTitleHolderResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformIvidTitleHolderResponse(_response, _dataProvider.Critical);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(new { transformer.Result }, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
