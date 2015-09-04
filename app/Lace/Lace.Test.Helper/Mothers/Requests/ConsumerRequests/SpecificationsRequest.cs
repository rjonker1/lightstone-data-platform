using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Consumers;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.ConsumerRequests
{
    public class SpecificationsRequest : IPointToLaceRequest
    {
        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get
            {
                return LighstoneConsumerSpecificationsRequest.LighstoneConsumerSpecificationsRequestPackage("AHTYZ59G408011576",
                    "99167DC9-A09D-4582-AECA-AE5D42B7F201");
            }
        }

        public IHaveRequestContext Request
        {
            get { return new RequestContextInformation(); }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }
    }
}
