using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessCompanyResponse : IProvideDataFromLightstoneBusinessCompany
    {
        public LightstoneBusinessCompanyResponse()
        {
            Companies = Enumerable.Empty<IProvideCompany>();
        }

        public static LightstoneBusinessCompanyResponse Empty()
        {
            return new LightstoneBusinessCompanyResponse();
        }

        public LightstoneBusinessCompanyResponse(IEnumerable<IProvideCompany> companies)
        {
            Companies = companies;
        }

        private LightstoneBusinessCompanyResponse(string message)
        {

            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static LightstoneBusinessCompanyResponse Failure(string message)
        {
            return new LightstoneBusinessCompanyResponse(message);
        }

        [DataMember]
        public IEnumerable<IProvideCompany> Companies { get; private set; }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

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

        [DataMember]
        public IAmLightstoneBusinessCompanyRequest Request { get; private set; }
    }
}