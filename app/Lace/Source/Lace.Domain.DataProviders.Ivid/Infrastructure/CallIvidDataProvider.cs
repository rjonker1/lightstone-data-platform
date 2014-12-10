using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class CallIvidDataProvider : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _response;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProvider Provider = DataProvider.Ivid;

        public CallIvidDataProvider(ILaceRequest request)
        {
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringMessages monitoring)
        {
            try
            {
                var ividWebService = new ConfigureIvidSource();

                ividWebService.ConfigureIvidWebServiceCredentials();
                ividWebService.ConfigureIvidWebServiceRequestMessageProperty();

                monitoring.DataProviderSecurity(Provider, ividWebService.IvidServiceProxy.ObjectToJson(), "Ivid Data Provider Credentials");

                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var request = new IvidRequestMessage(_request)
                        .Build()
                        .HpiQueryRequest;

                    monitoring.DataProviderConfiguration(Provider, request.ObjectToJson(), string.Empty);

                    monitoring.StartCallingDataProvider(Provider, request.ObjectToJson(), _stopWatch);

                    _response = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(request);

                    ividWebService.CloseWebService();

                    monitoring.EndCallingDataProvider(Provider,
                        _response != null ? _response.ObjectToJson() : new HpiStandardQueryResponse().ObjectToJson(),
                        _stopWatch);

                    if (_response == null)
                        monitoring.DataProviderFault(Provider, _request.ObjectToJson(),
                            "No response received from Ivid Data Provider");

                    TransformResponse(response, monitoring);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Data Provider {0}", ex.Message);
                monitoring.DataProviderFault(Provider, ex.Message.ObjectToJson(), "Error calling Ivid Data Provider");
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var transformer = new TransformIvidResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            monitoring.DataProviderTransformation(Provider, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
