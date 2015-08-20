using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstoneConsumerSpecificationsResponse : IProvideDataFromLightstoneConsumerSpecifications
    {
        public LightstoneConsumerSpecificationsResponse()
        {
            
        }

        public static LightstoneConsumerSpecificationsResponse Empty()
        {
            return new LightstoneConsumerSpecificationsResponse();
        }

        [DataMember]
        public IAmLightstoneConsumerSpecificationsRequest Request { get; private set; }

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
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
