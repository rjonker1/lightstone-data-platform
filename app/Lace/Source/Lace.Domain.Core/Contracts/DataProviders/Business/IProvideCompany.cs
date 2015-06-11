using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Business
{
    public interface IProvideCompany : IProvideType
    {
        int Id { get; }
        string EnterpriseType { get; }
        string ShortenType { get; }
        string CompanyRegNumber { get; }
        string OldRegistrationNumber { get; }
        string TypeDate { get; }
        string CompanyName { get; }
        string ShortName { get; }
        string TranslatedName { get; }
        string RegistrationDate { get; }
        string BusinessStartDate { get; }
        string WithdrawnPublic { get; }
        string StatusCode { get; }
        string StatusDate { get; }
        string SicCode { get; }
        string FinancialYearEnd { get; }
        string FinancialEffectiveDate { get; }
        string PhysicalAddress1 { get; }
        string PhysicalAddress2 { get; }
        string PhysicalAddress3 { get; }
        string PhysicalAddress4 { get; }
        string PhysicalPostCode { get; }
        string PostalAddress1 { get; }
        string PostalAddress2 { get; }
        string PostalAddress3 { get; }
        string PostalAddress4 { get; }
        string PostalPostCode { get; }
        string CountryCode { get; }
        string CountryOfOrigin { get; }
        string RegionCode { get; }
        double AuthorisedCapital { get; }
        double AuthorisedShares { get; }
        double IssuedCapital { get; }
        double IssuedShares { get; }
        string FormReceivedDate { get; }
        string FormDate { get; }
        string ConversionNumber { get; }
        string TaxNumber { get; }
        bool Cpa { get; }
        string StatusCodeDesc { get; }
        string RegionCodeDesc { get; }
        string SicDescription { get; }
    }
}