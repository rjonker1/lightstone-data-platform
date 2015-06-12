using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessDirectorResponse : IProvideDataFromLightstoneBusinessDirector
    {
        public LightstoneBusinessDirectorResponse()
        {
            
        }

        public LightstoneBusinessDirectorResponse(IEnumerable<IProvideDirector> directors)
        {
            Directors = directors;
        }

        [DataMember]
        public IEnumerable<IProvideDirector> Directors { get; private set; }

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
        public IAmLightstoneBusinessDirectorRequest Request { get; private set; }
      

      
    }
}
