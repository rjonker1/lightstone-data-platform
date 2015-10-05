using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class PCubedEzScoreBuilder
    {
         string _addressLine1;
         string _addressLine2;
         string _addressPostCode;
         string _addressProvince;
         string _addressSuburb;
         string _addressTownCity;
         string _creditGradeNonCpa;
         string _demDeceased;
         string _demGender;
         string _demHomeOwner;
         string _demLsm;
         string _demPredictedRace;
         string _emailAddress1;
         string _emailAddress2;
         string _emailAddress3;
         string _extractDate;
         string _fasNonCpaGroupDescriptionShort;
         string _firstName;
         string _idNumber;
         string _mosaicCpaGroupMerged;
         string _phone1;
         string _phone2;
         string _phone3;
         string _postalAddressLine1;
         string _postalAddressLine2;
         string _postalAddressPostCode;
         string _postalAddressProvince;
         string _postalAddressSuburb;
         string _postalAddressTownCity;
         string _surname;
         string _wealthIndex;

        public IRespondWithEzScore Build()
        {
            var ezScoreRecord = new EzScoreRecord();
            ezScoreRecord.WithHeader(_phone1, _phone2, _phone3, _emailAddress1, _emailAddress2, _emailAddress3, _surname, _firstName, _idNumber);
            ezScoreRecord.WithDetail(_demLsm, _fasNonCpaGroupDescriptionShort, _mosaicCpaGroupMerged, _wealthIndex,
                _creditGradeNonCpa, _demHomeOwner, _demDeceased, _demPredictedRace, _demGender, _postalAddressPostCode,
                _postalAddressProvince, _postalAddressTownCity, _postalAddressSuburb, _postalAddressLine2,
                _postalAddressLine1, _addressPostCode, _addressProvince, _addressTownCity, _addressSuburb, _addressLine2,
                _addressLine1, _extractDate);

            return ezScoreRecord;
        }

        public PCubedEzScoreBuilder WithHeader(string phone1, string phone2, string phone3, string emailAddress1, string emailAddress2, string emailAddress3, string surname, string firstName, string idNumber)
        {
            _phone1 = phone1;
            _phone2 = phone2;
            _phone3 = phone3;
            _emailAddress1 = emailAddress1;
            _emailAddress2 = emailAddress2;
            _emailAddress3 = emailAddress3;
            _surname = surname;
            _firstName = firstName;
            _idNumber = idNumber;
            return this;
        }

        public PCubedEzScoreBuilder WithDetail(string demLsm, string fasNonCpaGroupDescriptionShort, string mosaicCpaGroupMerged, string wealthIndex,
               string creditGradeNonCpa, string demHomeOwner, string demDeceased, string demPredictedRace, string demGender, string postalAddressPostCode,
               string postalAddressProvince, string postalAddressTownCity, string postalAddressSuburb, string postalAddressLine2,
               string postalAddressLine1, string addressPostCode, string addressProvince, string addressTownCity, string addressSuburb, string addressLine2,
               string addressLine1, string extractDate)
        {
            _demLsm = demLsm;
            _fasNonCpaGroupDescriptionShort = fasNonCpaGroupDescriptionShort;
            _mosaicCpaGroupMerged = mosaicCpaGroupMerged;
            _wealthIndex = wealthIndex;
            _creditGradeNonCpa = creditGradeNonCpa;
            _demHomeOwner = demHomeOwner;
            _demDeceased = demDeceased;
            _demPredictedRace = demPredictedRace;
            _demGender = demGender;
            _postalAddressPostCode = postalAddressPostCode;
            _postalAddressProvince = postalAddressProvince;
            _postalAddressTownCity = postalAddressTownCity;
            _postalAddressSuburb = postalAddressSuburb;
            _postalAddressLine2 = postalAddressLine2;
            _postalAddressLine1 = postalAddressLine1;
            _addressPostCode = addressPostCode;
            _addressProvince = addressProvince;
            _addressTownCity = addressTownCity;
            _addressSuburb = addressSuburb;
            _addressLine2 = addressLine2;
            _addressLine1 = addressLine1;
            _extractDate = extractDate;
            return this;
        }
    }
}