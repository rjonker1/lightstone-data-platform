using System;
using System.Collections.Generic;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Callers
{
    public class IvidApiAsyncCaller : AbstractIvidCaller, ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallIvidDataProvider>();
        private HpiStandardQueryResponse1 _response;
        private readonly HpiStandardQueryRequest _request;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public IvidApiAsyncCaller(ICallTheDataProviderSource next, HpiStandardQueryRequest request, IAmDataProvider dataProvider, ILogCommandTypes logCommand)
            : base(next)
        {
            _logCommand = logCommand;
            _request = request;
            _dataProvider = dataProvider;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                AsyncApiCall();
                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Async Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Ivid Async Data Provider"});
                IvidResponseFailed(response);
            }

            if (!response.HasRecords<IProvideDataFromIvid>()) CallNext(response);

        }

        private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = IvidResponse.WithState(DataProviderResponseState.TechnicalError);
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            if (_response == null || _response.HpiStandardQueryResponse == null) return;

            var transformer = new TransformIvidResponse(_response.HpiStandardQueryResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
                transformer.SetStatusMessages(_request);
            }

            _logCommand.LogTransformation(transformer.Result, null);
            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private async void AsyncApiCall()
        {
            var api = new ConfigureIvid();
            _logCommand.LogSecurity(
                new
                {
                    Credentials =
                        new
                        {
                            api.Client.ClientCredentials.UserName.UserName,
                            api.Client.ClientCredentials.UserName.Password
                        }
                },
                new {ContextMessage = "Ivid Async Data Provider Credentials"});

            _logCommand.LogConfiguration(_request, null);
            _logCommand.LogRequest(new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(), _request,
                _dataProvider.BillablleState.NoRecordState,string.Empty);

            _response = await api.Client.HpiStandardQueryAsync(_request);

            api.Close();

            _logCommand.LogResponse(CheckState(_response),
                new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString())
                .ForWebApiType(), _response ?? new HpiStandardQueryResponse1(), _dataProvider.BillablleState.NoRecordState, _response != null && _response.HpiStandardQueryResponse != null ?_response.HpiStandardQueryResponse.IvidReference : string.Empty);

            if (_response == null || _response.HpiStandardQueryResponse == null)
                _logCommand.LogFault(_dataProvider,
                    new {NoRequestReceived = "No response received from Ivid Async Data Provider"});
        }

        private static DataProviderResponseState CheckState(HpiStandardQueryResponse1 response)
        {
            return response == null
                ? DataProviderResponseState.NoRecords
                : response.HpiStandardQueryResponse.partialResponse ? DataProviderResponseState.Partial : DataProviderResponseState.Successful;
        }
    }
}