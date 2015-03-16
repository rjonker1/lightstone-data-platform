using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessResponse : IProvideDataFromLightstoneBusiness
    {
        public LightstoneBusinessResponse()
        {
            
        }

        public LightstoneBusinessResponse(IEnumerable<IRespondWithBusiness> result)
        {
            BusinessInformation = result;
        }

        [DataMember]
        public IEnumerable<IRespondWithBusiness> BusinessInformation { get; private set; }

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
