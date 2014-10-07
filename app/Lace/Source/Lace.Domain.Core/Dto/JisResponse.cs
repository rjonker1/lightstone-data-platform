using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Dto
{
    public class JisResponse : IProvideDataFromJis
    {
      
        public JisResponse(string caseNumber, string description, bool empty, string errorType, string id, bool isHot,
            bool limited, string policeStation, string status, int unicodeErrorCode, string vehicleChassisNumber,
            string vechicleDateStolen, string vehicleEngineNumber, string vehicleMake, string vehicleRegistration)
        {
            CaseNumber = caseNumber;
            Description = description;
            Empty = empty;
            ErrorType = errorType;
            Id = id;
            IsHot = isHot;
            Limited = limited;
            PoliceStation = policeStation;
            Status = status;
            UnicodeErrorCode = unicodeErrorCode;
            VehicleChassisNumber = vehicleChassisNumber;
            VehicleDateStolen = vechicleDateStolen;
            VehicleEngineNumber = vehicleEngineNumber;
            VehicleMake = vehicleMake;
            VehicleRegistration = vehicleRegistration;
        }

        public IProvideDataFromJis UpdateVehicelSightingInformation(int actionTaken, string comments, int noActionReason,
            string registrationNumber, int sightingId, byte[] vehicleImage, byte[] vehiclePlateImage)
        {
            ActionTaken = actionTaken;
            Comments = comments;
            NoActionReason = noActionReason;
            RegistrationNumber = registrationNumber;
            SightingId = sightingId;
            VehicleImage = vehicleImage != null ? Convert.ToBase64String(vehicleImage) : null;
            VehiclePlateImage = vehiclePlateImage != null ? Convert.ToBase64String(vehiclePlateImage) : null;

            return this;
        }


        public string CaseNumber { get; private set; }

        public string Description { get; private set; }

        public bool Empty { get; private set; }

        public bool Error { get; private set; }

        public string ErrorMessage { get; private set; }

        public string ErrorType { get; private set; }

        public string Id { get; private set; }

        public bool IsHot { get; private set; }

        public bool Limited { get; private set; }

        public string PoliceStation { get; private set; }

        public string Status { get; private set; }

        public int UnicodeErrorCode { get; private set; }

        public string VehicleChassisNumber { get; private set; }

        public string VehicleDateStolen { get; private set; }

        public string VehicleEngineNumber { get; private set; }

        public string VehicleMake { get; private set; }

        public string VehicleRegistration { get; private set; }

        public int ActionTaken { get; private set; }

        public string Comments { get; private set; }

        public List<IProvideHitStatusDataStoreNamesMapping> HitAndStatusSourceList { get; private set; }

        public int NoActionReason { get; private set; }

        public string RegistrationNumber { get; private set; }

        public int SightingId { get; private set; }

        public string VehicleImage { get; private set; }

        public string VehiclePlateImage { get; private set; }
    }
}
