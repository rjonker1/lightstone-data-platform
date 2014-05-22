using Lace.Request;

namespace Lace.Tests.Data.RequestData
{
    public class ContextInformation : ILaceRequestContext
    {
        public string Product
        {
            get
            {
                return "VVi+ADX+VPi";
            }
        }

        public string ReasonForApplication
        {
            get
            {
                return null;
            }
        }

        public string SecurityCode
        {
            get
            {
                return "c99ef6d2-fdea-4a81-b15f-ff8251ac9050";
            }
        }
    }
}
