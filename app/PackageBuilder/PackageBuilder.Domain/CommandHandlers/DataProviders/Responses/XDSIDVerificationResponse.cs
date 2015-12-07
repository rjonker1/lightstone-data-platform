using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Xds;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class XdsIdentityVerificationResponse
    {
        public Lace.Domain.Core.Entities.XdsIdentityVerificationResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.XdsIdentityVerificationResponse(new List<IRespondWithIdentityVerification>
            {
                new IdentityVerificationRecord(0, 0, "", "", "", "", "", "", "", 0, 0, "")
            });
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}