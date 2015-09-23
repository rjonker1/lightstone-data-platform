using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstonePropertyResponse : IProvideDataFromLightstoneProperty
    {
        public LightstonePropertyResponse()
        {
            PropertyInformation = Enumerable.Empty<IRespondWithProperty>();
        }

        private LightstonePropertyResponse(string message)
        {
            PropertyInformation = Enumerable.Empty<IRespondWithProperty>();
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static LightstonePropertyResponse Empty()
        {
            return new LightstonePropertyResponse();
        }

        public static LightstonePropertyResponse Failure(string message)
        {
            return new LightstonePropertyResponse(message);
        }

        public LightstonePropertyResponse(IEnumerable<IRespondWithProperty> properties)
        {
            PropertyInformation = properties;
        }

        [DataMember]
        public IAmLightstonePropertyRequest Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithProperty> PropertyInformation { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
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
    }
}