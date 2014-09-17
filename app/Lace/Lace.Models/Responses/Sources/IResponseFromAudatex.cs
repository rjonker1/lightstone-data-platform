using System.Collections.Generic;

namespace Lace.Models.Responses.Sources
{
    public interface IResponseFromAudatex : IPointToLaceSource
    {
        IList<IAccidentClaim> AccidentClaims { get; }

        void CleanAccidentClaims();

        void CheckForAccidentClaims(bool check);

        void ResetAccidentClaimFlag();

        void AddAccidentClaim(IAccidentClaim claim);

        bool HasAccidentClaims { get; }

        string QuoteValueIndicatorNote { get; }

        string LowConfidenceLevelIndicatorNote { get; }

        string RegistrationNumberOnlyIndicatorNote { get; }
    }
}
