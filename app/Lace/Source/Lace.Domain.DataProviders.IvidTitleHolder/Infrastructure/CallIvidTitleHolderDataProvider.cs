using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class CallIvidTitleHolderDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private TitleholderQueryResponse _response;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProviderCommandSource Provider = DataProviderCommandSource.IvidTitleHolder;

        public CallIvidTitleHolderDataProvider(ILaceRequest request)
        {
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            try
            {
               var ividTitleHolderWebService = new ConfigureIvidTitleHolderSource();

                ividTitleHolderWebService.ConfigureIvidTitleHolderServiceCredentials();
                ividTitleHolderWebService.ConfigureIvidTitleHolderWebServiceRequestMessageProperty();

                using (
                    var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                    var request = new IvidTitleHolderRequestMessage(_request, response)
                        .Build()
                        .TitleholderQueryRequest;


                    monitoring.DataProviderConfiguration(Provider,request.ObjectToJson(),string.Empty);

                    monitoring.StartCallingDataProvider(Provider, request.ObjectToJson(), _stopWatch);

                    _response = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(request);

                    ividTitleHolderWebService
                        .CloseWebService();

                    monitoring.EndCallingDataProvider(Provider, _response != null ? _response.ObjectToJson() : new TitleholderQueryResponse().ObjectToJson(), _stopWatch);

                    if (_response == null)
                        monitoring.DataProviderFault(Provider, _request.ObjectToJson(),
                       "No response received from Ivid Title Holder Data Provider");

                    TransformResponse(response, monitoring);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Title Holder Data Provider {0}", ex.Message);
                monitoring.DataProviderFault(Provider, ex.Message.ObjectToJson(), "Error calling Ivid Title Holder Data Provider");
                IvidTitleHolderResponseFailed(response);
            }
        }

        private static void IvidTitleHolderResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
        
        public void TransformResponse(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            var transformer = new TransformIvidTitleHolderResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }


            monitoring.DataProviderTransformation(Provider, transformer.Result.ObjectToJson(),
                transformer.ObjectToJson());

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
