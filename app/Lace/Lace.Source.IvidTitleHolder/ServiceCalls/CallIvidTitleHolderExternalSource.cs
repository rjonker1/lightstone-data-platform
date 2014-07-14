﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Events;
using Lace.Extensions;
using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.ServiceConfig;
using Lace.Source.IvidTitleHolder.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.IvidTitleHolder.ServiceCalls
{
    public class CallIvidTitleHolderExternalSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private TitleholderQueryResponse _ividTitleHolderResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.IvidTitleHolder;

        public CallIvidTitleHolderExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var ividTitleHolderWebService = new ConfigureIvidTitleHolderSource();

                ividTitleHolderWebService.ConfigureIvidTitleHolderServiceCredentials();
                ividTitleHolderWebService.ConfigureIvidTitleHolderWebServiceRequestMessageProperty();

                using (
                    var scope = new OperationContextScope(ividTitleHolderWebService.IvidTitleHolderProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividTitleHolderWebService.IvidTitleHolderRequestMessageProperty;

                    laceEvent.PublishEndSourceConfigurationMessage(Source);

                    var ividTitleHolderRequest = new ConfigureIvidTitleHolderRequestMessage(_request, response)
                        .Build()
                        .TitleholderQueryRequest;

                    laceEvent.PublishSourceRequestMessage(Source,
                        ividTitleHolderRequest.ObjectToJson());

                    laceEvent.PublishStartSourceCallMessage(Source);

                    _ividTitleHolderResponse = ividTitleHolderWebService
                        .IvidTitleHolderProxy
                        .TitleholderQuery(ividTitleHolderRequest);

                    laceEvent.PublishEndSourceCallMessage(Source);

                    ividTitleHolderWebService
                        .CloseWebService();

                    if (_ividTitleHolderResponse == null)
                        laceEvent.PublishNoResponseFromSourceMessage(Source);


                    laceEvent.PublishSourceResponseMessage(Source,
                        _ividTitleHolderResponse != null
                            ? _ividTitleHolderResponse.ObjectToJson()
                            : new TitleholderQueryResponse().ObjectToJson());

                    TransformResponse(response);
                }

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Title Holder Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessaage(Source);
                IvidTitleHolderResponseFailed(response);
            }
        }

        private static void IvidTitleHolderResponseFailed(ILaceResponse response)
        {
            response.IvidTitleHolderResponse = null;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
        
        public void TransformResponse(ILaceResponse response)
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
