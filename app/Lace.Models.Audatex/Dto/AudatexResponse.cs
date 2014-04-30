using System.Collections.Generic;
using Lace.Models.Enums;

namespace Lace.Models.Audatex.Dto
{
    public class AudatexResponse : IResponseFromAudatex
    {
        public string Error { get; set; }

        public IList<AccidentClaim> AccidentClaims { get; set; }

        public bool HasAccidentClaims { get; set; }

        public string QuoteValueIndicatorNote
        {
            get
            {
                return "* Indicates the repair quote band segment";
            }
        }

        public string LowConfidenceLevelIndicatorNote
        {
            get
            {
                return "! Indicates that we have a low confidence in the record returned";
            }
        }

        public string RegistrationNumberOnlyIndicatorNote
        {
            get
            {
                return "** This record is matched on Registration number only";
            }
        }

        public ServiceCallState ServiceProviderCallState { get; set; }
    }
}
