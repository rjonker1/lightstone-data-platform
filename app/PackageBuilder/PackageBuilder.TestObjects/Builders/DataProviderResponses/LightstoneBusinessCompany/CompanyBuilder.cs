using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class CompanyBuilder
    {
         int _id;
         bool _cpa;
         double _authorisedCapital;
         double _authorisedShares;
         double _issuedCapital;
         double _issuedShares;
         string _businessStartDate;
         string _companyName;
         string _companyRegNumber;
         string _conversionNumber;
         string _countryCode;
         string _countryOfOrigin;
         string _enterpriseType;
         string _financialEffectiveDate;
         string _financialYearEnd;
         string _formDate;
         string _formReceivedDate;
         string _oldRegistrationNumber;
         string _physicalAddress1;
         string _physicalAddress2;
         string _physicalAddress3;
         string _physicalAddress4;
         string _physicalPostCode;
         string _postalAddress1;
         string _postalAddress2;
         string _postalAddress3;
         string _postalAddress4;
         string _postalPostCode;
         string _regionCode;
         string _regionCodeDesc;
         string _registrationDate;
         string _shortenType;
         string _shortName;
         string _sicCode;
         string _sicDescription;
         string _statusCode;
         string _statusCodeDesc;
         string _statusDate;
         string _taxNumber;
         string _translatedName;
         string _typeDate;
         string _withdrawnPublic;

        public IProvideCompany Build()
        {
            var companyResponse = new CompanyResponse(_id, _enterpriseType, _shortenType, _companyRegNumber, _oldRegistrationNumber,
                _typeDate, _companyName, _shortName, _translatedName, _registrationDate, _businessStartDate, _withdrawnPublic,
                _statusCode, _statusDate, _sicCode, _financialYearEnd, _financialEffectiveDate);
            companyResponse.SetCompanyDetail(_authorisedCapital, _authorisedShares, _issuedCapital, _issuedShares,
                _formReceivedDate, _formDate, _conversionNumber, _taxNumber, _cpa, _statusCodeDesc, _regionCodeDesc,
                _sicDescription);
            companyResponse.SetPhysicalAddress(_physicalAddress1, _physicalAddress2, _physicalAddress3, _physicalAddress4,
                _physicalPostCode, _countryCode, _countryOfOrigin, _regionCode);
            companyResponse.SetPostalAddress(_postalAddress1, _postalAddress2, _postalAddress3, _postalAddress4, _postalPostCode);

            return companyResponse;
        }

        public CompanyBuilder With(int id)
        {
            _id = id;
            return this;
        }

        public CompanyBuilder With(bool cpa)
        {
            _cpa = cpa;
            return this;
        }

        public CompanyBuilder With(double authorisedCapital, double authorisedShares, double issuedCapital, double issuedShares)
        {
            _authorisedCapital = authorisedCapital;
            _authorisedShares = authorisedShares;
            _issuedCapital = issuedCapital;
            _issuedShares = issuedShares;
            return this;
        }

        public CompanyBuilder With(string businessStartDate, string companyName, string companyRegNumber, string conversionNumber,
         string countryCode, string countryOfOrigin, string enterpriseType, string financialEffectiveDate,
         string financialYearEnd, string formDate, string formReceivedDate, string oldRegistrationNumber,
         string physicalAddress1, string physicalAddress2, string physicalAddress3, string physicalAddress4,
         string physicalPostCode, string postalAddress1, string postalAddress2, string postalAddress3,
         string postalAddress4, string postalPostCode, string regionCode, string regionCodeDesc,
         string registrationDate, string shortenType, string shortName, string sicCode,
         string sicDescription, string statusCode, string statusCodeDesc, string statusDate,
         string taxNumber, string translatedName, string typeDate, string withdrawnPublic)
        {
            _businessStartDate = businessStartDate;
            _companyName = companyName;
            _companyRegNumber = companyRegNumber;
            _conversionNumber = conversionNumber;

            _countryCode = countryCode;
            _countryOfOrigin = countryOfOrigin;
            _enterpriseType = enterpriseType;
            _financialEffectiveDate = financialEffectiveDate;

            _financialYearEnd = financialYearEnd;
            _formDate = formDate;
            _formReceivedDate = formReceivedDate;
            _oldRegistrationNumber = oldRegistrationNumber;

            _physicalAddress1 = physicalAddress1;
            _physicalAddress2 = physicalAddress2;
            _physicalAddress3 = physicalAddress3;
            _physicalAddress4 = physicalAddress4;

            _physicalPostCode = physicalPostCode;
            _postalAddress1 = postalAddress1;
            _postalAddress2 = postalAddress2;
            _postalAddress3 = postalAddress3;

            _postalAddress4 = postalAddress4;
            _postalPostCode = postalPostCode;
            _regionCode = regionCode;
            _regionCodeDesc = regionCodeDesc;

            _registrationDate = registrationDate;
            _shortenType = shortenType;
            _shortName = shortName;
            _sicCode = sicCode;

            _sicDescription = sicDescription;
            _statusCode = statusCode;
            _statusCodeDesc = statusCodeDesc;
            _statusDate = statusDate;

            _taxNumber = taxNumber;
            _translatedName = translatedName;
            _typeDate = typeDate;
            _withdrawnPublic = withdrawnPublic;

            return this;
        }
    }
}