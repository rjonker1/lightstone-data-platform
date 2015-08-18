using Lace.Toolbox.PCubed.Extensions;

namespace Lace.Toolbox.PCubed.Domain
{
    public class Detail
    {
        private string _demLsm;
        private string _fasNonCPAGroupDescriptionShort;
        private string _mosaicCPAGroupMerged;
        private string _wealthIndex;
        private string _creditGradeNonCPA;
        private string _demHomeOwner;
        private string _demDeceased;
        private string _demPredictedRace;
        private string _demGender;
        private string _postalAddressPostCode;
        private string _postalAddressProvince;
        private string _postalAddressTownCity;
        private string _postalAddressSuburb;
        private string _postalAddressLine2;
        private string _postalAddressLine1;
        private string addressPostCode;
        private string addressProvince;
        private string addressTownCity;
        private string addressSuburb;
        private string addressLine2;
        private string addressLine1;
        private string extractDate;

        public bool DemMaritalStatus { get; set; }

        public bool DemDirector { get; set; }

        public bool DemEntrepreneur { get; set; }

        public bool DemDigitallyEnabled { get; set; }

        public bool CreditActiveNonCPA { get; set; }

        public int DemAge { get; set; }

        public string ExtractDate
        {
            get { return extractDate.Fix(); }
            set { extractDate = value; }
        }

        public string AddressLine1
        {
            get { return addressLine1.Fix(); }
            set { addressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return addressLine2.Fix(); }
            set { addressLine2 = value; }
        }

        public string AddressSuburb
        {
            get { return addressSuburb.Fix(); }
            set { addressSuburb = value; }
        }

        public string AddressTownCity
        {
            get { return addressTownCity.Fix(); }
            set { addressTownCity = value; }
        }

        public string AddressProvince
        {
            get { return addressProvince.Fix(); }
            set { addressProvince = value; }
        }

        public string AddressPostCode
        {
            get { return addressPostCode.Fix(); }
            set { addressPostCode = value; }
        }

        public string PostalAddressLine1
        {
            get { return _postalAddressLine1.Fix(); }
            set { _postalAddressLine1 = value; }
        }

        public string PostalAddressLine2
        {
            get { return _postalAddressLine2.Fix(); }
            set { _postalAddressLine2 = value; }
        }

        public string PostalAddressSuburb
        {
            get { return _postalAddressSuburb.Fix(); }
            set { _postalAddressSuburb = value; }
        }

        public string PostalAddressTownCity
        {
            get { return _postalAddressTownCity.Fix(); }
            set { _postalAddressTownCity = value; }
        }

        public string PostalAddressProvince
        {
            get { return _postalAddressProvince.Fix(); }
            set { _postalAddressProvince = value; }
        }

        public string PostalAddressPostCode
        {
            get { return _postalAddressPostCode.Fix(); }
            set { _postalAddressPostCode = value; }
        }

        public string DemGender
        {
            get { return _demGender.Fix(); }
            set { _demGender = value; }
        }

        public string DemPredictedRace
        {
            get { return _demPredictedRace.Fix(); }
            set { _demPredictedRace = value; }
        }

        public string DemDeceased
        {
            get { return _demDeceased.Fix(); }
            set { _demDeceased = value; }
        }

        public string DemHomeOwner
        {
            get { return _demHomeOwner.Fix(); }
            set { _demHomeOwner = value; }
        }

        public string CreditGradeNonCPA
        {
            get { return _creditGradeNonCPA.Fix(); }
            set { _creditGradeNonCPA = value; }
        }

        public string WealthIndex
        {
            get { return _wealthIndex.Fix(); }
            set { _wealthIndex = value; }
        }

        public string MosaicCPAGroupMerged
        {
            get { return _mosaicCPAGroupMerged.Fix(); }
            set { _mosaicCPAGroupMerged = value; }
        }

        public string FASNonCPAGroupDescriptionShort
        {
            get { return _fasNonCPAGroupDescriptionShort.Fix(); }
            set { _fasNonCPAGroupDescriptionShort = value; }
        }

        public string DemLSM
        {
            get { return _demLsm.Fix(); }
            set { _demLsm = value; }
        }
    }
}
