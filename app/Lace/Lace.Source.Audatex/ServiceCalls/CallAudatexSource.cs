using System;
using Common.Logging;
using Lace.Events;
using Lace.Extensions;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.ServiceConfig;
using Lace.Source.Audatex.Transform;
using Monitoring.Sources.Lace;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class CallAudatexSource : ICallTheSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Audatex;

        public CallAudatexSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            try
            {
                laceEvent.PublishStartSourceConfigurationMessage(Source);

                var audatexWebService = new ConfigureAudatexSource()
                    .Create();

                var audatexRequest = new ConfigureAudatexRequestMessage(response)
                    .Build()
                    .AudatexRequest;

                laceEvent.PublishEndSourceConfigurationMessage(Source);

                laceEvent.PublishSourceRequestMessage(Source,
                    audatexRequest.ObjectToJson());

                laceEvent.PublishStartSourceCallMessage(Source);

                _audatexResponse = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(GetCredentials(), audatexRequest.MessageType, audatexRequest.Message, 0);

                laceEvent.PublishEndSourceCallMessage(Source);

                audatexWebService
                    .Close();

                if (_audatexResponse == null)
                    laceEvent.PublishNoResponseFromSourceMessage(Source);

                laceEvent.PublishSourceResponseMessage(Source,
                    _audatexResponse != null ? _audatexResponse.ObjectToJson() : new GetDataResult().ObjectToJson());

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Audatex Source {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessaage(Source);
                AudatexResponseFailed(response);
            }
        }

        private static void AudatexResponseFailed(ILaceResponse response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }

        private static CredentialsInfo GetCredentials()
        {
            return new CredentialsInfo()
            {
                CompanyCode = Configuration.Credentials.AudatexCompanyCode(),
                Password = Configuration.Credentials.AudatexPassword(),
                UserId = Configuration.Credentials.AudatexUserId()
            };
        }

        public void TransformResponse(ILaceResponse response)
        {
            var transformer = new TransformAudatexResponse(_audatexResponse, response, _request);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }
    }
}
