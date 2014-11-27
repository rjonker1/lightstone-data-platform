﻿using System;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure
{
    public class CallAudatexDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private GetDataResult _response;
        private readonly ILaceRequest _request;
        private readonly DataProviderStopWatch _stopWatch;
        private const DataProvider Provider = DataProvider.Audatex;

        public CallAudatexDataProvider(ILaceRequest request)
        {
            _request = request;
            _stopWatch = new StopWatchFactory().StopWatchForDataProvider(Provider);
        }

        public void CallTheDataProvider(IProvideResponseFromLaceDataProviders response,
            ISendMonitoringMessages monitoring)
        {
            try
            {
                var audatexWebService = new ConfigureAudatexSource()
                    .Create();

                var request = new ConfigureAudatexRequestMessage(response)
                    .Build()
                    .AudatexRequest;

                monitoring.StartCallingDataProvider(Provider, request.ObjectToJson(), _stopWatch);

                _response = audatexWebService
                    .AudatexServiceProxy
                    .GetDataEx(GetCredentials(), request.MessageType, request.Message, 0);

                monitoring.EndCallingDataProvider(Provider, _response.ObjectToJson(), _stopWatch);

                audatexWebService
                    .Close();

                if (_response == null)
                    //      monitoring.PublishNoResponseFromSourceMessage(Source);

                    //   monitoring.PublishSourceResponseMessage(Source,
                    //       _audatexResponse != null ? _audatexResponse.ObjectToJson() : new GetDataResult().ObjectToJson());

                    TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Audatex Source {0}", ex.Message);
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
            var transformer = new TransformAudatexResponse(_response, response, _request);

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
