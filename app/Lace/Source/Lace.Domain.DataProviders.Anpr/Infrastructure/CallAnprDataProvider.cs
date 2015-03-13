using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.CrossCutting.DataProvider.Certificate.Core.Contracts;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Dto;
using Lace.CrossCutting.DataProvider.Certificate.Infrastructure.Factory;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Anpr.AnprServiceReference;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Dto;
using Lace.Domain.DataProviders.Anpr.Infrastructure.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class CallAnprDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ILaceRequest _request;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;

        public CallAnprDataProvider(ILaceRequest request, ISetupCertificateRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
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

                TransformResponse(response, monitoring);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
                AnprResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response, ISendMonitoringCommandsToBus monitoring)
        {
            var transformer = new TransformAnprResponse(_anprResponse, _request.RequestAggregation.AggregateId);
            if (transformer.Continue)
            {
                transformer.Transform();
            }

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private static void AnprResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var anprResponse = new AnprResponse();
            anprResponse.HasBeenHandled();
            response.Add(anprResponse);
        }
    }
}
