using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
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
