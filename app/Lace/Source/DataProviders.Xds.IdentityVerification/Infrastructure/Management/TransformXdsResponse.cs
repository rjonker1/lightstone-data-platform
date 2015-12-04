using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataProviders.Xds.IdentityVerification.Infrastructure.Dto;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Xds;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;

namespace DataProviders.Xds.IdentityVerification.Infrastructure.Management
{
    public class TransformXdsResponse :  ITransform
    {
        public ListOfConsumers Response { get; private set; }
        public TransformXdsResponse(ListOfConsumers response)
        {
            Response = response;
            Continue = response != null && response.ConsumerDetails != null;
            Result = Continue ? null : XdsIdentityVerificationResponse.Empty();
        }

        public void Transform()
        {
            var s = Response.ConsumerDetails;
            var verifications = new IdentityVerificationRecord(s.Idno, s.ConsumerID, s.HomeAffairsID, s.FirstName, s.SecondName, s.Surname, s.DeceasedStatus,
                    s.IDIssuedDate, s.CauseOfDeath, s.EnquiryID, s.EnquiryResultID, s.Reference);

            Result = new XdsIdentityVerificationResponse(new List<IRespondWithIdentityVerification>() { verifications });
            Result.AddResponseState(!Result.IdentityVerifications.Any()? DataProviderResponseState.NoRecords : DataProviderResponseState.Successful);
        }

        public IProvideDataFromXdsIdentityVerification Result { get; private set; }
        public bool Continue { get; private set; }
    }
}
