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
            Properties = properties;
        }

        [DataMember]
        public IEnumerable<IRespondWithProperty> Properties { get; private set; }

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
    }
}
