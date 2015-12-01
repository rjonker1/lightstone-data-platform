using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
    public class IvidApiCaller : AbstractIvidCaller, ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<IvidApiCaller>();
        private readonly ILogCommandTypes _logCommand;
        private readonly HpiStandardQueryRequest _request;
        private HpiStandardQueryResponse _response;
        
        private readonly IAmDataProvider _dataProvider;

        public IvidApiCaller(ICallTheDataProviderSource next, HpiStandardQueryRequest request, IAmDataProvider dataProvider, ILogCommandTypes logCommand) 
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
                    new { ContextMessage = "Ivid Data Provider Credentials" });

                using (var scope = new OperationContextScope(webService.Client.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        webService.RequestMessageProperty;

                    _logCommand.LogConfiguration(_request, null);
                    _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _request, _dataProvider.BillablleState.NoRecordState, string.Empty);

                    _response = webService
                        .Client
                        .HpiStandardQuery(_request);

                    webService.Close();

                    _logCommand.LogResponse(CheckState(_response),
                        new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), _response ?? new HpiStandardQueryResponse(), _dataProvider.BillablleState.NoRecordState, _response != null ? _response.IvidReference : string.Empty );

                    if (_response == null)
                        _logCommand.LogFault(_dataProvider,
                            new { NoRequestReceived = "No response received from Ivid Data Provider" });

                    TransformResponse(response);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling Ivid Data Provider" });
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
            var transformer = new TransformIvidResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
                transformer.SetStatusMessages(_request);
            }

            _logCommand.LogTransformation(transformer.Result, null);
            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static DataProviderResponseState CheckState(HpiStandardQueryResponse response)
        {
            return response == null
                ? DataProviderResponseState.NoRecords
                : response.partialResponse ? DataProviderResponseState.Partial : DataProviderResponseState.Successful;
        }
    }
}
