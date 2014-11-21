using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Shared;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure
{
    public class CallIvidExternalSource : ICallTheDataProviderSource
    {
        private HpiStandardQueryResponse _ividResponse;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Ivid;

        public CallIvidExternalSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ISendMonitoringMessages monitoring)
        {
            try
            {
              //  monitoring.PublishStartSourceConfigurationMessage(Source);

                var ividWebService = new ConfigureIvidSource();

                ividWebService.ConfigureIvidWebServiceCredentials();
                ividWebService.ConfigureIvidWebServiceRequestMessageProperty();


                using (var scope = new OperationContextScope(ividWebService.IvidServiceProxy.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                        ividWebService.IvidRequestMessageProperty;

                    var ividRequest = new IvidRequestMessage(_request)
                    .Build()
                    .HpiQueryRequest;

                  //  monitoring.PublishEndSourceConfigurationMessage(Source);

                  //  monitoring.PublishSourceRequestMessage(Source,
                  //      ividRequest.ObjectToJson());

                  //  monitoring.PublishStartSourceCallMessage(Source);

                    _ividResponse = ividWebService
                        .IvidServiceProxy
                        .HpiStandardQuery(ividRequest);

                //    monitoring.PublishEndSourceCallMessage(Source);

                    ividWebService.CloseWebService();

                    if (_ividResponse == null)
              //          monitoring.PublishNoResponseFromSourceMessage(Source);

              //      monitoring.PublishSourceResponseMessage(Source,
              //          _ividResponse != null ? _ividResponse.ObjectToJson() : new HpiStandardQueryResponse().ObjectToJson());

                    TransformResponse(response);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Ivid Web Service {0}", ex.Message);
             //   monitoring.PublishFailedSourceCallMessage(Source);
                IvidResponseFailed(response);
            }
        }

        private static void IvidResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.IvidResponse = null;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformIvidResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
