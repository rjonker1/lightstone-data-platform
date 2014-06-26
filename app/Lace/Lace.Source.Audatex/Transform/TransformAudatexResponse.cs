using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Extensions;
using Lace.Models.Audatex.Dto;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.Compare;

namespace Lace.Source.Audatex.Transform
{
    public class TransformAudatexResponse : ITransform
    {
        public GetDataResult Message { get; private set; }
        public AudatexResponse Result { get; private set; }
        public bool Continue { get; private set; }

        private List<HistoryCheckResponse> HistoryCheckResponses
        {
            get
            {
                var models = Message.MessageEnvelope.XmlToObject<VendorResponse>();
                return models == null ? new List<HistoryCheckResponse>() : models.Body.EntityList;
            }
        }

        private readonly ILaceResponse _response;
        private readonly ILaceRequest _request;

        private readonly string _manufacturer;
        private readonly int _warrantyYear;
        private readonly bool _canApplyRepairInfo;

        public TransformAudatexResponse(GetDataResult audatexResponse, ILaceResponse response, ILaceRequest request)
        {
            Continue = audatexResponse != null && !string.IsNullOrEmpty(audatexResponse.MessageEnvelope);
            Result = Continue ? new AudatexResponse() {AccidentClaims = new List<AccidentClaim>()} : null;
            Message = audatexResponse;

            _response = response;
            _request = request;

            _manufacturer = GetManufacturer();
            _canApplyRepairInfo = !string.IsNullOrEmpty(_manufacturer);

            _warrantyYear = GetYear();
        }

        public void Transform()
        {
            Result.HasAccidentClaims = false;
            DateTime? notAvailbleDate = null;

            HistoryCheckResponses
                .ForEach(f =>
                {
                    if (CompareRequestedAndResponseData.ShowClaim(_request.Vehicle.Vin, _manufacturer, f.VIN, f.Manufacturer,
                        _warrantyYear, f.CreationDate, _request.Vehicle.LicenceNo, f.Registration))
                    {
                        var claim = new AccidentClaim()
                        {
                            AccidentDate = f.AccidentDate.HasValue ? f.AccidentDate.Value : notAvailbleDate,
                            AssessmentNumber = f.AssessmentNumber,
                            ClaimReferenceNumber = f.ClaimReferenceNumber,
                            CreationDate = f.CreationDate,
                            DataSource = f.DataSource,
                            Manufacturer = f.Manufacturer,
                            Mileage = f.Mileage,
                            Model = f.Model,
                            Originator = f.Originator,
                            Registration = f.Registration,
                            RepairCostExVat = f.RepairCostExVAT,
                            RepairCostIncVat = f.RepairCostIncVAT,
                            VersionDate = f.VersionDate,
                            Vin = f.VIN,
                            QuoteValueIndicator =
                                string.Format("{0} {1}", TransformRepairCosts.Transform(f.RepairCostExVAT),
                                    CompareRequestedAndResponseData.MatchInformation(_request.Vehicle.Vin, _manufacturer, f.VIN,
                                        f.Manufacturer, _request.Vehicle.LicenceNo, f.Registration, _canApplyRepairInfo)),
                            CreationDateString = GetCreationDateString(f.CreationDate)

                        };

                        Result.HasAccidentClaims |= !string.IsNullOrEmpty(claim.AssessmentNumber) ||
                                                    claim.RepairCostExVat.HasValue;
                        AddAccidentClaim(claim);
                    }

                });

            AccidentClaimCleaner.CleanAccidentClaims(Result);
        }


        private string GetManufacturer()
        {
            if (_response.RgtResponse == null) return GetManufacturerFromRgtVin() ?? string.Empty;

            return _response.RgtResponse.Manufacturer ?? string.Empty;
        }

        private string GetManufacturerFromRgtVin()
        {
            if (_response.RgtVinResponse == null) return null;

            return _response.RgtVinResponse.VehicleMake ?? string.Empty;
        }

        private int GetYear()
        {
            if (_response.LightstoneResponse == null) return 1900;

            return _response.LightstoneResponse.Year ?? 1900;
        }

        private static string GetCreationDateString(DateTime? creationDate)
        {
            var creationDateString = creationDate.HasValue &&
                                     (creationDate.Value.ToShortDateString() != "0001-01-01" &&
                                      creationDate.Value.ToShortDateString() != "0001/01/01")
                ? creationDate.Value.ToShortDateString()
                : "Date Not Available";

            return creationDateString;
        }

        private void AddAccidentClaim(AccidentClaim claim)
        {
            if (Result.AccidentClaims.Any(ac => ac.Equals(claim))) return;

            Result.AccidentClaims.Add(claim);
        }
    }
}
