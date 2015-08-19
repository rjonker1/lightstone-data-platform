using Lace.Toolbox.PCubed.Extensions;

namespace Lace.Toolbox.PCubed.Domain
{
    public class Detail
    {
        private string _demLsm;
        private string _fasNonCpaGroupDescriptionShort;
        private string _mosaicCpaGroupMerged;
        private string _wealthIndex;
        private string _creditGradeNonCpa;
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
        private string _addressPostCode;
        private string _addressProvince;
        private string _addressTownCity;
        private string _addressSuburb;
        private string _addressLine2;
        private string _addressLine1;
        private string _extractDate;

        public bool DemMaritalStatus { get; set; }

        public bool DemDirector { get; set; }

        public bool DemEntrepreneur { get; set; }

        public bool DemDigitallyEnabled { get; set; }

        public bool CreditActiveNonCPA { get; set; }

        public int DemAge { get; set; }

        public string ExtractDate
        {
            get { return _extractDate.Fix(); }
            set { _extractDate = value; }
        }

        public string AddressLine1
        {
            get { return _addressLine1.Fix(); }
            set { _addressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return _addressLine2.Fix(); }
            set { _addressLine2 = value; }
        }

        public string AddressSuburb
        {
            get { return _addressSuburb.Fix(); }
            set { _addressSuburb = value; }
        }

        public string AddressTownCity
        {
            get { return _addressTownCity.Fix(); }
            set { _addressTownCity = value; }
        }

        public string AddressProvince
        {
            get { return _addressProvince.Fix(); }
            set { _addressProvince = value; }
        }

        public string AddressPostCode
        {
            get { return _addressPostCode.Fix(); }
            set { _addressPostCode = value; }
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
            get { return _creditGradeNonCpa.Fix(); }
            set { _creditGradeNonCpa = value; }
        }

        public string WealthIndex
        {
            get { return _wealthIndex.Fix(); }
            set { _wealthIndex = value; }
        }

        public string MosaicCPAGroupMerged
        {
            get { return _mosaicCpaGroupMerged.Fix(); }
            set { _mosaicCpaGroupMerged = value; }
        }

        public string FASNonCPAGroupDescriptionShort
        {
            get { return _fasNonCpaGroupDescriptionShort.Fix(); }
            set { _fasNonCpaGroupDescriptionShort = value; }
        }

        public string DemLSM
        {
            get { return _demLsm.Fix(); }
            set { _demLsm = value; }
        }
    }
}
