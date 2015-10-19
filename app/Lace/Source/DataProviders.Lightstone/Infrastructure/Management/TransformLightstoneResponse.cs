using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Toolbox.Database.Base;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Management
{
    public class TransformLightstoneResponse : ITransform
    {
        public IProvideDataFromLightstoneAuto Result { get; private set; }
        private readonly IRetrieveValuationFromMetrics _metricResponse;
        private readonly IRetrieveCarInformation _carInformation;

        public TransformLightstoneResponse(IRetrieveValuationFromMetrics metricResponse,
            IRetrieveCarInformation carInformation)
        {
            Continue = metricResponse != null && carInformation != null && carInformation.CarInformationDto != null && carInformation.IsSatisfied && metricResponse.IsSatisfied;
            Result = Continue ? null : LightstoneAutoResponse.Empty();

            _metricResponse = metricResponse;
            _carInformation = carInformation;
        }

        public void Transform()
        {
            Result = new LightstoneAutoResponse(_carInformation.CarInformationDto.CarId, _carInformation.CarInformationDto.Year,
                _carInformation.CarInformationRequest.Vin, _carInformation.CarInformationDto.ImageUrl,
                _carInformation.CarInformationDto.Quarter,
                _carInformation.CarInformationDto.CarFullname, _carInformation.CarInformationDto.CarModel,
                _metricResponse.Valuation);
            Result.AddResponseState(DataProviderResponseState.Successful);
        }

        public bool Continue { get; private set; }
    }
}
