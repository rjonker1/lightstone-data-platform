using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management;
using Lace.Shared.Extensions;
using Lace.Toolbox.PCubed;
using Lace.Toolbox.PCubed.Domain;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using RestSharp;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure
{
    public sealed class CallPCubedEzScoreDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private IRestResponse<ConsumerViewResponse> _response;

        public CallPCubedEzScoreDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _logCommand.LogRequest(new ConnectionTypeIdentifier(ConfigurationProvider.ConsumerViewApiUrl)
                    .ForWebApiType(), new { _dataProvider }, _dataProvider.BillablleState.NoRecordState);

                _response =
                    new ConsumerViewService(new RestClient()).Search(HandleRequest.GetQuery(_dataProvider.GetRequest<IAmPCubedEzScoreRequest>()));

                _logCommand.LogResponse(response != null && response.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords,
                    new ConnectionTypeIdentifier(ConfigurationProvider.ConsumerViewApiUrl)
                        .ForDatabaseType(), new { _response }, _dataProvider.BillablleState.NoRecordState);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling PCubed EzScore Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling  PCubed EzScore Data Provider"});
                PCubedEzScoreResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformPCubedEzScoreResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private void PCubedEzScoreResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ezScoreResponse = PCubedEzScoreResponse.WithState(DataProviderResponseState.TechnicalError);
            ezScoreResponse.HasBeenHandled();
            response.Add(ezScoreResponse);
        }
    }
}