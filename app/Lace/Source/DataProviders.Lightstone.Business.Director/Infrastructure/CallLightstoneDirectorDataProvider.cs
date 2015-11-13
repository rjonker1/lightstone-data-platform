using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure
{
    public sealed class CallLightstoneBusinessDirectorDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private DataSet _result;

        public CallLightstoneBusinessDirectorDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var api = new ConfigureApi();
                if (api.UserToken == Guid.Empty)
                    throw new Exception("Cannot continue calling Lightstone Business Directory Api. User is not valid");

                _logCommand.LogSecurity(new {Credentials = new {api.Username, api.Password}},
                    new {Message = "Lightstone Business Data Provider Credentials"});

                var request = new DirectorRequest(_dataProvider.GetRequest<IAmLightstoneBusinessDirectorRequest>()).Map().Validate();
                if (!request.IsValid)
                    throw new Exception("Cannot continue call Lightstone Business Director Api. Request is not valid");

                _logCommand.LogRequest(new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(),
                    new { _dataProvider }, _dataProvider.BillablleState.NoRecordState);

                DirectorDataRetriever.Start(api, request).WithReturnDirectors().ThenConfirmDirector().FinallyGetDirectorReport(out _result);

                _logCommand.LogResponse(_result == null || _result.Tables.Count == 0 ? DataProviderResponseState.NoRecords : DataProviderResponseState.Successful,
                    new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(), new { _result }, _dataProvider.BillablleState.NoRecordState);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Director Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Business Director Data Provider"});
                LightstoneDirectorResponseFailed(response);
            }
        }

        private static void LightstoneDirectorResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneDirectorResponse = LightstoneBusinessDirectorResponse.WithState(DataProviderResponseState.TechnicalError);
            lightstoneDirectorResponse.HasBeenHandled();
            response.Add(lightstoneDirectorResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneDirectorResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? LightstoneBusinessDirectorResponse.Empty(), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}