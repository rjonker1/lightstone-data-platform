﻿using System;
using Common.Logging;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Shared.Extensions;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class CallAudatexSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;
        private const LaceEventSource Source = LaceEventSource.Audatex;

        public CallAudatexSource(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
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
                laceEvent.PublishFailedSourceCallMessage(Source);
                AudatexResponseFailed(response);
            }
        }

        private static void AudatexResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.AudatexResponse = null;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }

        private static CredentialsInfo GetCredentials()
        {
            return new CredentialsInfo()
            {
                CompanyCode = Credentials.AudatexCompanyCode(),
                Password = Credentials.AudatexPassword(),
                UserId = Credentials.AudatexUserId()
            };
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
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
