using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;

namespace Lace.Domain.Core.Entities
{
    public class PCubedEzScoreResponse : IProvideDataFromPCubedEzScore
    {
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

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }

        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}