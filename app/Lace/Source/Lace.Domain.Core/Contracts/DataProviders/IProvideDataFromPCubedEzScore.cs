using System;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromPCubedEzScore
    {
        Guid EzScoreRecordId { get; }
        Guid DriverLicenceScanId { get; }

        //header
        string EmailAddress1 { get; }
        string EmailAddress2 { get; }
        string EmailAddress3 { get; }
        string FirstName { get; }
        string IdNumber { get; }
        string Phone1 { get; }
        string Phone2 { get; }
        string Phone3 { get; }
        string Surname { get; }

        //details
        string AddressLine1 { get; }
        string AddressLine2 { get; }
        string AddressPostCode { get; }
        string AddressProvince { get; }
        string AddressSuburb { get; }
        string AddressTownCity { get; }
        bool CreditActiveNonCpa { get; }
        string CreditGradeNonCpa { get; }
        int DemAge { get; }
        string DemDeceased { get; }
        bool DemDigitallyEnabled { get; }
        bool DemDirector { get; }
        bool DemEntrepreneur { get; }
        string DemGender { get; }
        string DemHomeOwner { get; }
        string DemLsm { get; }
        bool DemMaritalStatus { get; }
        string DemPredictedRace { get; }
        string ExtractDate { get; }
        string FasNonCpaGroupDescriptionShort { get; }
        string MosaicCpaGroupMerged { get; }
        string PostalAddressLine1 { get; }
        string PostalAddressLine2 { get; }
        string PostalAddressPostCode { get; }
        string PostalAddressProvince { get; }
        string PostalAddressSuburb { get; }
        string PostalAddressTownCity { get; }
        string WealthIndex { get; }

        string CustomerConsentSignatureBase64 { get; }
        string CustomerConsentSignAt { get; }

        DateTime DateCreated { get; }
        string CreatedBy { get; }
        int NumberOfDaysOld { get; } 
    }
}
