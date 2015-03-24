using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Management
{
    public class TransformAudatexResponse : ITransformResponseFromDataProvider
    {
        public GetDataResult Message { get; private set; }
        public AudatexResponse Result { get; private set; }
        public bool Continue { get; private set; }

        private IEnumerable<HistoryCheckResponse> HistoryCheckResponses
        {
            get
            {
                var models = Message.MessageEnvelope.XmlToObject<VendorResponse>();
                return models == null ? new List<HistoryCheckResponse>() : models.Body.EntityList;
            }
        }

        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ILaceRequest _request;

        private readonly string _manufacturer;
        private readonly int _warrantyYear;
        private readonly bool _canApplyRepairInfo;

        public TransformAudatexResponse(GetDataResult audatexResponse, ICollection<IPointToLaceProvider> response,
            ILaceRequest request)
        {
            Continue = audatexResponse != null && !string.IsNullOrEmpty(audatexResponse.MessageEnvelope);
            Result = new AudatexResponse(new List<IProvideAccidentClaim>());
            Message = audatexResponse;

            _response = response;
            _request = request;

            _manufacturer = GetManufacturer();
            _canApplyRepairInfo = !string.IsNullOrEmpty(_manufacturer);

            _warrantyYear = GetYear();
        }

        public void Transform()
        {
            Result.ResetAccidentClaimFlag();

            foreach (var f in HistoryCheckResponses)
            {
                var compare = new CompareRequestAndResponse(_request.Vehicle.Vin, _manufacturer,
                    f.VIN,
                    f.Manufacturer, _request.Vehicle.LicenceNo, f.Registration, _canApplyRepairInfo);

                if (!compare.ShowClaim(_warrantyYear, f.CreationDate))
                    continue;

                var claim = new AccidentClaim(
                    f.AccidentDate.HasValue ? f.AccidentDate.Value : (DateTime?) null,
                    f.AssessmentNumber, f.ClaimReferenceNumber, f.CreationDate, f.DataSource, f.InsuredName,
                    f.Manufacturer, f.Mileage, f.Model,
                    f.Originator, f.PolicyNumber, f.Registration, f.RepairCostExVAT, f.RepairCostIncVAT,
                    f.VersionDate, f.VIN, f.WorkproviderReference, f.MatchType,
                    string.Format("{0} {1}", TransformRepairCosts.Transform(f.RepairCostExVAT),
                        compare.GetMatchIndicator()));

                Result.CheckForAccidentClaims(!string.IsNullOrEmpty(claim.AssessmentNumber) ||
                                              claim.RepairCostExVat.HasValue);

                Result.AddAccidentClaim(claim);
            }
            Result.CleanAccidentClaims();
        }


        private string GetManufacturer()
        {
            if (!_response.OfType<IProvideDataFromRgt>().Any() ||
                _response.OfType<IProvideDataFromRgt>().First() == null)
                return GetManufacturerFromRgtVin() ?? string.Empty;

            return _response.OfType<IProvideDataFromRgt>().First().Manufacturer ?? string.Empty;
        }

        private string GetManufacturerFromRgtVin()
        {
            if (!_response.OfType<IProvideDataFromRgtVin>().Any() ||
                _response.OfType<IProvideDataFromRgtVin>().First() == null) return null;

            return _response.OfType<IProvideDataFromRgtVin>().First().VehicleMake ?? string.Empty;
        }

        private int GetYear()
        {
            if (!_response.OfType<IProvideDataFromLightstoneAuto>().Any() ||
                _response.OfType<IProvideDataFromLightstoneAuto>().First() == null) return 1900;

            return _response.OfType<IProvideDataFromLightstoneAuto>().First().Year ?? 1900;
        }
    }
}
