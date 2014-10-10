using System;
using System.ServiceModel;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Dto;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Monitoring.Sources.Lace;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class CallAnprExternalSource : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private const LaceEventSource Source = LaceEventSource.Anpr;

        private readonly ILaceRequest _request;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;

        public CallAnprExternalSource(ILaceRequest request, ISetupCertificateRepository repository)
        {
            _request = request;
            _repository = repository;
        }

        public void CallTheExternalSource(IProvideResponseFromLaceDataProviders response, ILaceEvent laceEvent)
        {
            try
            {
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(_request.CoOrdinates.Latitude, _request.CoOrdinates.Longitude),
                        _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null ||
                    string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    AnprResponseFailed(response);

                var proxy = new AnprServiceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                var builder = new BuildAnprRequest(_request).Build();
                _anprResponse = proxy.AnprProcessRecognition(builder.AnprRequest);

                proxy.Close();

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
                laceEvent.PublishFailedSourceCallMessage(Source);
                AnprResponseFailed(response);
            }
        }

        public void TransformResponse(IProvideResponseFromLaceDataProviders response)
        {
            var transformer = new TransformAnprResponse(_anprResponse, _request.RequestAggregation.AggregateId);
            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.AnprResponse = transformer.Result;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasBeenHandled();
        }

        private static void AnprResponseFailed(IProvideResponseFromLaceDataProviders response)
        {
            response.AnprResponse = null;
            response.AnprResponseHandled = new AnprResponseHandled();
            response.AnprResponseHandled.HasBeenHandled();
        }
    }
}
