using System.Collections.Generic;

namespace Lace.Models.Responses.Sources
{
    public interface IProvideDataFromAudatex : IPointToLaceProvider
    {
        IList<IProvideAccidentClaim> AccidentClaims { get; }

        void CleanAccidentClaims();

        void CheckForAccidentClaims(bool check);

        void ResetAccidentClaimFlag();

        void AddAccidentClaim(IProvideAccidentClaim claim);

        bool HasAccidentClaims { get; }

        string QuoteValueIndicatorNote { get; }

        string LowConfidenceLevelIndicatorNote { get; }

        string RegistrationNumberOnlyIndicatorNote { get; }
    }
}
