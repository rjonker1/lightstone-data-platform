using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicAndVinNumberIvidAndLsAutoProvidersRequest : IPointToLaceRequest
    {
        public IHavePackageForRequest Package
        {
            get
            {
                return LicAndVinIvidLsAutPackage.LicenseNumberAndVinNumberPackage("BZ11VPGP", "WAUZZZ8K8DA074674", "VVi+LSAuto"); // // //ADMRF80AN5E226402
            }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
