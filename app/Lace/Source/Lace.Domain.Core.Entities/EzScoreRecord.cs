using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class EzScoreRecord : IRespondWithEzScore
    {
        public EzScoreRecord()
        {
            
        }

        public EzScoreRecord WithReference(Guid ezScoreRecordId, Guid driverLicenceScanId)
        {
            EzScoreRecordId = ezScoreRecordId;
            DriverLicenceScanId = driverLicenceScanId;
            return this;
        }

        public EzScoreRecord WithHeader(string phone1, string phone2, string phone3, string emailAddress1, string emailAddress2, string emailAddress3,
            string surname, string firstName, string idnumber)
        {
            Phone1 = phone1;
            Phone2 = phone2;
            Phone3 = phone3;
            EmailAddress1 = emailAddress1;
            EmailAddress2 = emailAddress2;
            EmailAddress3 = emailAddress3;
            Surname = surname;
            FirstName = firstName;
            IdNumber = idnumber;
            return this;
        }

        public EzScoreRecord WithDetail(string demLsm, string fasNonCpaGroupDescriptionShort, string mosaicCpaGroupMerged, string wealthIndex, string creditGradeNonCpa, string demHomeOwner, string demDeceased, string demPredictedRace, string demGender,
            string postalAddressPostCode,string postalAddressProvince,string postalAddressTownCity,string postalAddressSuburb,string postalAddressLine2,string postalAddressLine1,string addressPostCode,string addressProvince,
            string addressTownCity,string addressSuburb,string addressLine2,string addressLine1,string extractDate)
        {
            DemLsm = demLsm;
            FasNonCpaGroupDescriptionShort = fasNonCpaGroupDescriptionShort;
            MosaicCpaGroupMerged = mosaicCpaGroupMerged;
            WealthIndex = wealthIndex;
            CreditActiveNonCpa = GetBool(creditGradeNonCpa);
            DemHomeOwner = demHomeOwner;
            DemDeceased = demDeceased;
            DemPredictedRace = demPredictedRace;
            DemGender = demGender;
            PostalAddressPostCode = postalAddressPostCode;
            PostalAddressProvince = postalAddressProvince;
            PostalAddressTownCity = postalAddressTownCity;
            PostalAddressSuburb = postalAddressSuburb;
            PostalAddressLine1 = postalAddressLine1;
            PostalAddressLine2 = postalAddressLine2;
            AddressPostCode = addressPostCode;
            AddressProvince = addressProvince;
            AddressTownCity = addressTownCity;
            AddressSuburb = addressSuburb;
            AddressLine2 = addressLine2;
            AddressLine1 = addressLine1;
            ExtractDate = extractDate;
            return this;
        }

        private static bool GetBool(string value)
        {
            bool val;
            bool.TryParse(value, out val);
            return val;
        }


        [DataMember]
        public Guid EzScoreRecordId { get; private set; }

        [DataMember]
        public Guid DriverLicenceScanId { get; private set; }

        [DataMember]
        public string EmailAddress1 { get; private set; }

        [DataMember]
        public string EmailAddress2 { get; private set; }

        [DataMember]
        public string EmailAddress3 { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string IdNumber { get; private set; }

        [DataMember]
        public string Phone1 { get; private set; }

        [DataMember]
        public string Phone2 { get; private set; }

        [DataMember]
        public string Phone3 { get; private set; }

        [DataMember]
        public string Surname { get; private set; }

        [DataMember]
        public string AddressLine1 { get; private set; }

        [DataMember]
        public string AddressLine2 { get; private set; }

        [DataMember]
        public string AddressPostCode { get; private set; }

        [DataMember]
        public string AddressProvince { get; private set; }

        [DataMember]
        public string AddressSuburb { get; private set; }

        [DataMember]
        public string AddressTownCity { get; private set; }

        [DataMember]
        public bool CreditActiveNonCpa { get; private set; }

        [DataMember]
        public string CreditGradeNonCpa { get; private set; }

        [DataMember]
        public int DemAge { get; private set; }

        [DataMember]
        public string DemDeceased { get; private set; }

        [DataMember]
        public bool DemDigitallyEnabled { get; private set; }

        [DataMember]
        public bool DemDirector { get; private set; }

        [DataMember]
        public bool DemEntrepreneur { get; private set; }

        [DataMember]
        public string DemGender { get; private set; }

        [DataMember]
        public string DemHomeOwner { get; private set; }

        [DataMember]
        public string DemLsm { get; private set; }

        [DataMember]
        public bool DemMaritalStatus { get; private set; }

        [DataMember]
        public string DemPredictedRace { get; private set; }

        [DataMember]
        public string ExtractDate { get; private set; }

        [DataMember]
        public string FasNonCpaGroupDescriptionShort { get; private set; }

        [DataMember]
        public string MosaicCpaGroupMerged { get; private set; }

        [DataMember]
        public string PostalAddressLine1 { get; private set; }

        [DataMember]
        public string PostalAddressLine2 { get; private set; }

        [DataMember]
        public string PostalAddressPostCode { get; private set; }

        [DataMember]
        public string PostalAddressProvince { get; private set; }

        [DataMember]
        public string PostalAddressSuburb { get; private set; }

        [DataMember]
        public string PostalAddressTownCity { get; private set; }

        [DataMember]
        public string WealthIndex { get; private set; }

        [DataMember]
        public string CustomerConsentSignatureBase64 { get; private set; }

        [DataMember]
        public string CustomerConsentSignAt { get; private set; }

        [DataMember]
        public DateTime DateCreated { get; private set; }

        [DataMember]
        public string CreatedBy { get; private set; }

        [DataMember]
        public int NumberOfDaysOld { get; private set; }
    }
}
