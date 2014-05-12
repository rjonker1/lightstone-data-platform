using Lace.Request;

namespace Lace.Tests.Data
{
    public class AccidentClaimField : IField
    {
        public int SourceId
        {
            get
            {
                return 4;
            }
        }

        public string Name
        {
            get
            {
                return "AccidentClaims";
            }
        }
    }
}
