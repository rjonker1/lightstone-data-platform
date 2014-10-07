using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Infrastructure.Management
{
    public class TransformJisResponse : ITransform
    {
        public bool Continue { get; private set; }
        public IProvideDataFromJis Result { get; private set; }

        private readonly DataStoreResult _response;
        private readonly SightingUpdateResult _sightingResponse;

        public TransformJisResponse(DataStoreResult response, SightingUpdateResult sightingResponse)
        {
            Continue = response != null;
            _response = response;
            _sightingResponse = sightingResponse;
        }

        public void Transform()
        {
            if (_response == null || _response.UnicodeResults == null)
                return;

            Result = _sightingResponse == null || _sightingResponse.VehicleSightingResult == null
                ? ResultWithoutSightingResponse()
                : ResultWithSightingResponse();

        }

        private IProvideDataFromJis ResultWithoutSightingResponse()
        {
            return new JisResponse(_response.UnicodeResults.CaseNumber, _response.UnicodeResults.Description,
                _response.UnicodeResults.Empty, _response.UnicodeResults.ErrorType.ToString(),
                _response.UnicodeResults.Id, _response.UnicodeResults.IsHot, _response.UnicodeResults.Limited,
                _response.UnicodeResults.PoliceStation, _response.UnicodeResults.Status,
                _response.UnicodeResults.UnicodeErrorCode, _response.UnicodeResults.VehicleChassisNumber,
                _response.UnicodeResults.VehicleDateStolen, _response.UnicodeResults.VehicleEngineNumber,
                _response.UnicodeResults.VehicleMake, _response.UnicodeResults.VehicleRegistration);
        }

        private IProvideDataFromJis ResultWithSightingResponse()
        {
            return new JisResponse(_response.UnicodeResults.CaseNumber, _response.UnicodeResults.Description,
                _response.UnicodeResults.Empty, _response.UnicodeResults.ErrorType.ToString(),
                _response.UnicodeResults.Id, _response.UnicodeResults.IsHot, _response.UnicodeResults.Limited,
                _response.UnicodeResults.PoliceStation, _response.UnicodeResults.Status,
                _response.UnicodeResults.UnicodeErrorCode, _response.UnicodeResults.VehicleChassisNumber,
                _response.UnicodeResults.VehicleDateStolen, _response.UnicodeResults.VehicleEngineNumber,
                _response.UnicodeResults.VehicleMake, _response.UnicodeResults.VehicleRegistration)
                .UpdateVehicelSightingInformation(_response.VehicleSightingResults.ActionTaken,
                    _response.VehicleSightingResults.Comments, _response.VehicleSightingResults.NoActionReason,
                    _response.VehicleSightingResults.RegistrationNr, _response.VehicleSightingResults.SightingId,
                    _response.VehicleSightingResults.VehicleImage,
                    _response.VehicleSightingResults.VehiclePlateImage);
        }
    }
}
