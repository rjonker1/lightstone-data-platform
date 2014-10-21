﻿using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Audatex.Infrastructure.Dto;
using Lace.Domain.DataProviders.Audatex.Management;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Source.Audatex.Transform;

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

        private readonly IProvideResponseFromLaceDataProviders _response;
        private readonly ILaceRequest _request;

        private readonly string _manufacturer;
        private readonly int _warrantyYear;
        private readonly bool _canApplyRepairInfo;

        public TransformAudatexResponse(GetDataResult audatexResponse, IProvideResponseFromLaceDataProviders response, ILaceRequest request)
        {
            Continue = audatexResponse != null && !string.IsNullOrEmpty(audatexResponse.MessageEnvelope);
            Result = Continue ? new AudatexResponse(new List<IProvideAccidentClaim>()) : null;
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
                if (
                    !CompareRequestedAndResponseData.ShowClaim(_request.Vehicle.Vin, _manufacturer, f.VIN,
                        f.Manufacturer,
                        _warrantyYear, f.CreationDate, _request.Vehicle.LicenceNo, f.Registration)) continue;

                var claim = new AccidentClaim(
                    f.AccidentDate.HasValue ? f.AccidentDate.Value : (DateTime?) null,
                    f.AssessmentNumber, f.ClaimReferenceNumber, f.CreationDate, f.DataSource, f.InsuredName,
                    f.Manufacturer, f.Mileage, f.Model,
                    f.Originator, f.PolicyNumber, f.Registration, f.RepairCostExVAT, f.RepairCostIncVAT,
                    f.VersionDate, f.VIN, f.WorkproviderReference, f.MatchType,
                    string.Format("{0} {1}", TransformRepairCosts.Transform(f.RepairCostExVAT),
                        CompareRequestedAndResponseData.MatchInformation(_request.Vehicle.Vin, _manufacturer,
                            f.VIN,
                            f.Manufacturer, _request.Vehicle.LicenceNo, f.Registration, _canApplyRepairInfo)));


                Result.CheckForAccidentClaims(!string.IsNullOrEmpty(claim.AssessmentNumber) ||
                                              claim.RepairCostExVat.HasValue);

                Result.AddAccidentClaim(claim);
            }

            Result.CleanAccidentClaims();
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
    }
}