using System.Collections.Generic;
using Lace.Models.Audatex.Dto;
using Lace.Models.Enums;

namespace Lace.Models.Audatex
{
    public interface IResponseFromAudatex
    {
        IList<AccidentClaim> AccidentClaims { get; }

        void CleanAccidentClaims();

        void CheckForAccidentClaims(bool check);

        void ResetAccidentClaimFlag();

        void AddAccidentClaim(AccidentClaim claim);

        bool HasAccidentClaims { get; }

        string QuoteValueIndicatorNote { get; }

        string LowConfidenceLevelIndicatorNote { get; }

        string RegistrationNumberOnlyIndicatorNote { get; }

       // ServiceCallState ServiceProviderCallState { get; }
    }
}
