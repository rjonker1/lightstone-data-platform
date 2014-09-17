using System;

namespace Lace.Models.Responses.Sources
{
    public interface IProvideAccidentClaim
    {
        Guid Key { get; }
        DateTime? AccidentDate { get; }
        string AssessmentNumber { get; }
        string ClaimReferenceNumber { get; }
        DateTime? CreationDate { get; }
        string CreationDateString { get; }
        string DataSource { get; }
        string InsuredName { get; }
        string Manufacturer { get; }
        string Mileage { get; }
        string Model { get; }
        string Originator { get; }
        string PolicyNumber { get; }
        string Registration { get; }
        decimal? RepairCostExVat { get; }
        decimal? RepairCostIncVat { get; }
        DateTime? VersionDate { get; }
        string Vin { get; }
        string WorkproviderReference { get; }
        string MatchType { get; }
        string QuoteValueIndicator { get; }
    }
}