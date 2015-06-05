using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessCompanyResponse : IProvideDataFromLightstoneBusinessCompany
    {
        public LightstoneBusinessCompanyResponse()
        {
            
        }

        public LightstoneBusinessCompanyResponse(IEnumerable<IProvideCompany> companies)
        {
            Companies = companies;
        }

        [DataMember]
        public IEnumerable<IProvideCompany> Companies { get; private set; }

        [DataMember]
        public Type Type
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
