using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Configuration;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Dto;
using Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure.Management;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.IvidTitleHolder.Infrastructure
{
    public class CallIvidTitleHolderExternalSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private TitleholderQueryResponse _ividTitleHolderResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.IvidTitleHolder;

        public CallIvidTitleHolderExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            try
            {
               // monitoring.PublishStartSourceConfigurationMessage(Source);

                var ividTitleHolderWebService = new ConfigureIvidTitleHolderSource();

                ividTitleHolderWebService.ConfigureIvidTitleHolderServiceCredentials();
                ividTitleHolderWebService.ConfigureIvidTitleHolderWebServiceRequestMessageProperty();

                using (
                    var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                 //   monitoring.PublishEndSourceConfigurationMessage(Source);

                    var ividTitleHolderRequest = new IvidTitleHolderRequestMessage(_request, response)
                        .Build()
                        .TitleholderQueryRequest;

                    //monitoring.PublishSourceRequestMessage(Source,
                    //    ividTitleHolderRequest.ObjectToJson());

                  //  monitoring.PublishStartSourceCallMessage(Source);

                    _ividTitleHolderResponse = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(ividTitleHolderRequest);

                 //   monitoring.PublishEndSourceCallMessage(Source);

                    ividTitleHolderWebService
                        .CloseWebService();

                    if (_ividTitleHolderResponse == null)
                 //       monitoring.PublishNoResponseFromSourceMessage(Source);


                    //monitoring.PublishSourceResponseMessage(Source,
                    //    _ividTitleHolderResponse != null
                    //        ? _ividTitleHolderResponse.ObjectToJson()
                    //        : new TitleholderQueryResponse().ObjectToJson());

                    TransformResponse(response);
                }

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Title Holder Web Service {0}", ex.Message);
              //  monitoring.PublishFailedSourceCallMessage(Source);
                IvidTitleHolderResponseFailed(response);
            }
        }

        private static void IvidTitleHolderResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
        
        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformIvidTitleHolderResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
