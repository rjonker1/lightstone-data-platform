using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Toolbox.Database.Base;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Management
{
    public class TransformLightstoneResponse : ITransformResponseFromDataProvider
    {
        public bool Continue { get; private set; }
        public IProvideDataFromLightstoneAuto Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;
        private readonly IRetrieveCarInformation _carInformation;


        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse,
            IRetrieveCarInformation carInformation)
        {
            Continue = metricResponse != null && metricResponse.IsSatisfied;
            Result = Continue ? null : new LightstoneAutoResponse() ;

            _metricResponse = metricResponse;
            _carInformation = carInformation;
        }

        public void Transform()
        {
            Result = new LightstoneAutoResponse(_carInformation.CarInformation.CarId, _carInformation.CarInformation.Year,
                _carInformation.CarInformationRequest.Vin, _carInformation.CarInformation.ImageUrl,
                _carInformation.CarInformation.Quarter,
                _carInformation.CarInformation.CarFullname, _carInformation.CarInformation.CarModel,
                _metricResponse.Valuation);
        }
    }
}
