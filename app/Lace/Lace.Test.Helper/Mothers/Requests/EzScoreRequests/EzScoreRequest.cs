using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Business;
using Lace.Test.Helper.Builders.EzScore;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests.EzScoreRequests
{
    public class EzScoreRequest : IPointToLaceRequest
    {
        public DateTime RequestDate
        {
            get { return DateTime.Now; }
        }

        public IHavePackageForRequest Package
        {
            get { return PCubedEzScoreSourcePackage.PCubedEzScoreRequestPackage("4810100045085","",""); }
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
