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
        private static readonly ILog Log = LogManager.GetLogger<CallIvidTitleHolderDataProvider>();
        private TitleholderQueryResponse _response;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public CallIvidTitleHolderDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
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
                Log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex, ex.Message);
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
                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new { request }, _dataProvider.BillablleState.NoRecordState, string.Empty);

                _response = webService
                    .Client
                    .TitleholderQuery(request);

                webService.Close();

                _logCommand.LogResponse(_response == null ? DataProviderResponseState.NoRecords : DataProviderResponseState.Successful,
                    new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _response ?? new TitleholderQueryResponse(), _dataProvider.BillablleState.NoRecordState, string.Empty);

                if (_response == null)
                    _logCommand.LogFault(new {_dataProvider}, new {NoRequestReceived = "No response received from Ivid Title Holder Data Provider"});
            }
        }

        private static void IvidTitleHolderResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividTitleHolderResponse = IvidTitleHolderResponse.WithState(DataProviderResponseState.TechnicalError);
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

            _logCommand.LogTransformation(new { transformer.Result }, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
