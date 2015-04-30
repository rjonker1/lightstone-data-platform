using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
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
using Lace.Shared.Extensions;
using Workflow.Lace.Messages.Core;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class CallAnprDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISetupCertificateRepository _repository;
        private IProvideCertificate _certificate;
        private AnprResComplexType _anprResponse;

        private readonly ISendCommandToBus command; //TODO:remove

        public CallAnprDataProvider(ICollection<IPointToLaceRequest> request, ISetupCertificateRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _request = request;
            _repository = repository;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                _certificate =
                    new CoOrdinateCertificateFactory(
                        new CoOrdinateCertificateRequest(_request.GetFromRequest<IHaveCoOrdinates>().Latitude, _request.GetFromRequest<IHaveCoOrdinates>().Longitude),
                        _repository);

                if (!_certificate.IsSuccessfull || _certificate.Certificate == null ||
                    string.IsNullOrEmpty(_certificate.Certificate.Endpoint))
                    AnprResponseFailed(response);

                var proxy = new AnprServiceSoapClient(_certificate.Certificate.Endpoint);
                if (proxy.State == CommunicationState.Closed)
                    proxy.Open();

                var builder = new BuildAnprRequest(_request.GetFromRequest<IHaveCoOrdinates>()).Build();
                _anprResponse = proxy.AnprProcessRecognition(builder.AnprRequest);

                proxy.Close();

                TransformResponse(response);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Anpr Web Service {0}", ex.Message);
                AnprResponseFailed(response);
            }
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformAnprResponse(_anprResponse, _request.GetFromRequest<IPointToVehicleRequest>().Request.RequestId);
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
