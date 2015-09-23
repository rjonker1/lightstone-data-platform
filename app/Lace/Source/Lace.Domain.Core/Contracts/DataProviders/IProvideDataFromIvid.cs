using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromIvid : IPointToLaceProvider, IProvideCriticalFailure
    {
        IAmIvidStandardRequest Request { get; set; }
        IProvideVehicleSpecificInformation SpecificInformation { get; }
        string StatusMessage { get; }
        string Reference { get; }
        string License { get; }
        string Registration { get; }
        string RegistrationDate { get; }
        string Vin { get; }
        string Engine { get; }
        string Displacement { get; }
        string Tare { get; }
        string MakeCode { get; }
        string MakeDescription { get; }
        string ModelCode { get; }
        string ModelDescription { get; }
        string ColourCode { get; }
        string ColourDescription { get; }
        string DrivenCode { get; }
        string DrivenDescription { get; }
        string CategoryCode { get; }
        string CategoryDescription { get; }
        string DescriptionCode { get; }
        string Description { get; }
        string EconomicSectorCode { get; }
        string EconomicSectorDescription { get; }
        string LifeStatusCode { get; }
        string LifeStatusDescription { get; }
        string SapMarkCode { get; }
        string SapMarkDescription { get; }
        bool HasIssues { get; }
        bool HasErrors { get; }
        bool HasNoRecords { get; }
        string CarFullname { get; }
        List<string> ReportStatusMessages { get; }
    }
}
