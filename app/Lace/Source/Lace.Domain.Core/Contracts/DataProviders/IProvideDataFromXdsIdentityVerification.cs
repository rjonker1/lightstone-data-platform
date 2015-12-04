using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Xds;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromXdsIdentityVerification : IPointToLaceProvider
    {
        IAmXdsIdentificationVerificationRequest Request { get; }
        IEnumerable<IRespondWithIdentityVerification> IdentityVerifications { get; }
       
    }
}
