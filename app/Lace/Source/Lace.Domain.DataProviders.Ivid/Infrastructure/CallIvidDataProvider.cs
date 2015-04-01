using System;
using System.Collections.Generic;
using System.Linq;
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
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Factories;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class CallIvidDataProvider : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _response;
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.Ivid;

        public CallIvidDataProvider(ICollection<IPointToLaceRequest> request)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            try
            {
                var ividWebService = new ConfigureIvidSource();

                monitoring.Send(CommandType.Security,
                    new
                    {
                        Credentials =
                            new
                            {
                                ividWebService.IvidServiceProxy.ClientCredentials.UserName.UserName,
                                ividWebService.IvidServiceProxy.ClientCredentials.UserName.Password
                            }
                    },
                    new {ContextMessage = "Ivid Data Provider Credentials"});

                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var request = new IvidRequestMessage(_request.GetFromRequest<IAmVehicleRequest>().User, _request.GetFromRequest<IAmVehicleRequest>().Vehicle, _request.GetFromRequest<IAmVehicleRequest>().Package.Name)
                        .HpiQueryRequest;

                    monitoring.Send(CommandType.Configuration, request, null);

                    monitoring.StartCall(request, _stopWatch);

                    _response = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(request);

                    ividWebService.CloseWebService();

                    monitoring.EndCall(_response ?? new HpiStandardQueryResponse(), _stopWatch);

                    if (_response == null)
                        monitoring.Send(CommandType.Fault, _request,
                            new {NoRequestReceived = "No response received from Ivid Data Provider"});

                    TransformResponse(response, monitoring);
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Ivid Data Provider {0}", ex.Message);
                monitoring.Send(CommandType.Fault, ex.Message, new {ErrorMessage = "Error calling Ivid Data Provider"});
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ividResponse = new IvidResponse();
            ividResponse.HasBeenHandled();
            response.Add(ividResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response,
            ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformIvidResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.Send(CommandType.Transformation, transformer.Result, transformer);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
