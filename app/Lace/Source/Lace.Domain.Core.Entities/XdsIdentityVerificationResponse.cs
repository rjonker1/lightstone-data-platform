using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Xds;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class XdsIdentityVerificationResponse : IProvideDataFromXdsIdentityVerification
    {
        public XdsIdentityVerificationResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            IdentityVerifications = Enumerable.Empty<IRespondWithIdentityVerification>();
        }

        public static XdsIdentityVerificationResponse Empty()
        {
            return new XdsIdentityVerificationResponse();
        }

        private XdsIdentityVerificationResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            IdentityVerifications = Enumerable.Empty<IRespondWithIdentityVerification>();
        }

        public static XdsIdentityVerificationResponse WithState(DataProviderResponseState state)
        {
            return new XdsIdentityVerificationResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public XdsIdentityVerificationResponse(IEnumerable<IRespondWithIdentityVerification> identityVerifications)
        {
            IdentityVerifications = identityVerifications;
        }

        [DataMember]
        public IAmXdsIdentificationVerificationRequest Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithIdentityVerification> IdentityVerifications { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }

        [DataMember]
        public string ResponseStateMessage
        {
            get { return ResponseState.Description(); }
        }
    }
}