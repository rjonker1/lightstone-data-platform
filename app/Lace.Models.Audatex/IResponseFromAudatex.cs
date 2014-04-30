using System.Collections.Generic;
using Lace.Models.Audatex.Dto;
using Lace.Models.Enums;

namespace Lace.Models.Audatex
{
    public interface IResponseFromAudatex
    {

        string Error { get; set; }

        IList<AccidentClaim> AccidentClaims { get; set; }
        bool HasAccidentClaims { get; set; }

        string QuoteValueIndicatorNote
        {
            get;
        }


        string LowConfidenceLevelIndicatorNote
        {
            get;
        }


        string RegistrationNumberOnlyIndicatorNote
        {
            get;
        }

        ServiceCallState ServiceProviderCallState { get; set; }
    }
}
