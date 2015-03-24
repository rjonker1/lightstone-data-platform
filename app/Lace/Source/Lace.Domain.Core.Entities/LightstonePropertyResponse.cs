using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstonePropertyResponse : IProvideDataFromLightstoneProperty
    {
        public LightstonePropertyResponse()
        {
            
        }

        public LightstonePropertyResponse(IEnumerable<IRespondWithProperty> properties)
        {
            PropertyInformation = properties;
        }

        [DataMember]
        public IEnumerable<IRespondWithProperty> PropertyInformation { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

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
