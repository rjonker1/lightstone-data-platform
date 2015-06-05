using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class CompanyResponse : IProvideCompany
    {
        public CompanyResponse(int id, string enterpriseType, string shortenType, string companyRegNumber, string oldRegNumber,
            string typeDate, string companyName,
            string shortName, string translatedName, string registrationDate, string businessStartDate, string withdrawnPublic, string statusCode,
            string statusDate, string sicCode, string financialYearEnd, string financialEffectiveDate)
        {
            Id = id;
            EnterpriseType = enterpriseType;
            ShortenType = shortenType;
            CompanyRegNumber = companyRegNumber;
            OldRegistrationNumber = oldRegNumber;
            TypeDate = typeDate;
            CompanyName = companyName;
            ShortName = shortName;
            TranslatedName = translatedName;
            RegistrationDate = registrationDate;
            BusinessStartDate = businessStartDate;
            WithdrawnPublic = withdrawnPublic;
            StatusCode = statusCode;
            StatusDate = statusDate;
            SicCode = sicCode;
            FinancialYearEnd = financialYearEnd;
            FinancialEffectiveDate = financialEffectiveDate;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string EnterpriseType { get; private set; }

        [DataMember]
        public string ShortenType { get; private set; }

        [DataMember]
        public string CompanyRegNumber { get; private set; }

        [DataMember]
        public string OldRegistrationNumber { get; private set; }

        [DataMember]
        public string TypeDate { get; private set; }

        [DataMember]
        public string CompanyName { get; private set; }

        [DataMember]
        public string ShortName { get; private set; }

        [DataMember]
        public string TranslatedName { get; private set; }

        [DataMember]
        public string RegistrationDate { get; private set; }

        [DataMember]
        public string BusinessStartDate { get; private set; }

        [DataMember]
        public string WithdrawnPublic { get; private set; }

        [DataMember]
        public string StatusCode { get; private set; }

        [DataMember]
        public string StatusDate { get; private set; }

        [DataMember]
        public string SicCode { get; private set; }

        [DataMember]
        public string FinancialYearEnd { get; private set; }

        [DataMember]
        public string FinancialEffectiveDate { get; private set; }

        public CompanyResponse SetPhysicalAddress(string address, string address2, string address3, string address4, string postalCode,
            string countryCode, string countryOfOrigin, string regionCode)
        {
            PhysicalAddress1 = address;
            PhysicalAddress2 = address2;
            PhysicalAddress3 = address3;
            PhysicalAddress4 = address4;
            PhysicalPostCode = postalCode;
            CountryCode = countryCode;
            CountryOfOrigin = countryOfOrigin;
            RegionCode = regionCode;
            return this;
        }

        [DataMember]
        public string PhysicalAddress1 { get; private set; }

        [DataMember]
        public string PhysicalAddress2 { get; private set; }

        [DataMember]
        public string PhysicalAddress3 { get; private set; }

        [DataMember]
        public string PhysicalAddress4 { get; private set; }

        [DataMember]
        public string PhysicalPostCode { get; private set; }

        public CompanyResponse SetPostalAddress(string address, string address2, string address3, string address4, string postalCode)
        {
            PostalAddress1 = address;
            PostalAddress2 = address2;
            PostalAddress3 = address3;
            PostalAddress4 = address4;
            PostalPostCode = postalCode;
            return this;
        }

        [DataMember]
        public string PostalAddress1 { get; private set; }

        [DataMember]
        public string PostalAddress2 { get; private set; }

        [DataMember]
        public string PostalAddress3 { get; private set; }

        [DataMember]
        public string PostalAddress4 { get; private set; }

        [DataMember]
        public string PostalPostCode { get; private set; }

        [DataMember]
        public string CountryCode { get; private set; }

        [DataMember]
        public string CountryOfOrigin { get; private set; }

        [DataMember]
        public string RegionCode { get; private set; }

        public CompanyResponse SetCompanyDetail(double authorisedCapital, double authorisedShares, double issuedCapital, double issuedShares,
            string formRecivedDate, string formDate, string conversionNumber, string taxNumber, bool cpa, string statusCodeDesc,
            string regionCodeDesc, string sicDescription)
        {
            AuthorisedCapital = authorisedCapital;
            AuthorisedShares = authorisedShares;
            IssuedCapital = issuedCapital;
            IssuedShares = issuedShares;
            FormReceivedDate = formRecivedDate;
            FormDate = formDate;
            ConversionNumber = conversionNumber;
            TaxNumber = taxNumber;
            Cpa = cpa;
            StatusCodeDesc = statusCodeDesc;
            RegionCodeDesc = regionCodeDesc;
            SicDescription = sicDescription;
            return this;
        }

        [DataMember]
        public double AuthorisedCapital { get; private set; }

        [DataMember]
        public double AuthorisedShares { get; private set; }

        [DataMember]
        public double IssuedCapital { get; private set; }

        [DataMember]
        public double IssuedShares { get; private set; }

        [DataMember]
        public string FormReceivedDate { get; private set; }

        [DataMember]
        public string FormDate { get; private set; }

        [DataMember]
        public string ConversionNumber { get; private set; }

        [DataMember]
        public string TaxNumber { get; private set; }

        [DataMember]
        public bool Cpa { get; private set; }

        [DataMember]
        public string StatusCodeDesc { get; private set; }

        [DataMember]
        public string RegionCodeDesc { get; private set; }

        [DataMember]
        public string SicDescription { get; private set; }


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
    }
}