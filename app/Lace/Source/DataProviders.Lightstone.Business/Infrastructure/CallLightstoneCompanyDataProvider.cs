using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure
{
    public sealed class CallLightstoneBusinessCompanyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private DataSet _result;

        public CallLightstoneBusinessCompanyDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
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
                    throw new Exception("Cannot continue calling Lightstone Business Api. User is not valid");

                _logCommand.LogSecurity(new {Credentials = new {api.Username, api.Password}},
                    new {Message = "Lightstone Business Data Provider Credentials"});

                var request = new CompanyRequest(_dataProvider.GetRequest<IAmLightstoneBusinessCompanyRequest>()).Map().Validate();
                if (!request.IsValid)
                    throw new Exception("Cannot continue call Lightstone Business Api. Request is not valid");

                _logCommand.LogRequest(new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(),
                    new { _dataProvider }, _dataProvider.BillablleState.NoRecordState);

                CompanyDataRetriever.Start(api, request).WithReturnCompanies().ThenConfirmCompany().FinallyGetCompanyReport(out _result);

                _logCommand.LogResponse(_result == null || _result.Tables.Count == 0 ? DataProviderResponseState.NoRecords : DataProviderResponseState.Successful,
                    new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(), new { _result }, _dataProvider.BillablleState.NoRecordState);

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Business Data Provider"});
                LightstoneBusinessResponseFailed(response);
            }
        }

        private static void LightstoneBusinessResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneBusinessResponse = LightstoneBusinessCompanyResponse.WithState(DataProviderResponseState.TechnicalError);
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneCompanyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? LightstoneBusinessCompanyResponse.Empty(), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}