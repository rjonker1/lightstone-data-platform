using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Business
{
    public class CompanySourcePackage
    {
        public static IHavePackageForRequest CompanyPackage(string companyName, string companyRegNumber, string companyVatNumber)
        {

            return new CompanyPackage(companyName, companyRegNumber, companyVatNumber);
        }
    }

    public class CompanyPackage : IHavePackageForRequest
    {
        private readonly string _companyName;
        private readonly string _companyRegNumber;
        private readonly string _companyVatNumber;

        public CompanyPackage(string companyName, string companyRegNumber, string companyVatNumber)
        {
            _companyName = companyName;
            _companyRegNumber = companyRegNumber;
            _companyVatNumber = companyVatNumber;
        }

        public Guid Id
        {
            get
            {
                return Guid.NewGuid();
            }
        }

        public long Version
        {
            get { return 1; }
        }

        public IAmDataProvider[] DataProviders
        {
            get { return new IAmDataProvider[] { new DataProvider(DataProviderName.LightstoneBusinessCompany, 50, 27, LightstoneBusinessCompanyRequest.WithDefault(_companyName,_companyRegNumber,_companyVatNumber)) }; }
        }

        public string Name
        {
            get { return "Companies Package"; }
        }
    }
}
