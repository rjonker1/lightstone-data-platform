using System.Collections.Generic;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromJis
    {
        string CaseNumber { get; }

        string Description { get; }

        bool Empty { get; }

        bool Error { get; }

        string ErrorMessage { get; }

        string ErrorType { get; }

        string Id { get; }

        bool IsHot { get; }

        bool Limited { get; }

        string PoliceStation { get; }

        string Status { get; }

        int UnicodeErrorCode { get; }

        string VehicleChassisNumber { get; }

        string VehicleDateStolen { get; }

        string VehicleEngineNumber { get; }

        string VehicleMake { get; }

        string VehicleRegistration { get; }

        int ActionTaken { get; }

        string Comments { get; }

        List<IProvideHitStatusDataStoreNamesMapping> HitAndStatusSourceList { get; }

        int NoActionReason { get; }

        string RegistrationNumber { get; }

        int SightingId { get; }

        string VehicleImage { get; }

        string VehiclePlateImage { get; }
    }
}
