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
    public class LightstoneBusinessDirectorResponse : IProvideDataFromLightstoneBusinessDirector
    {
        public LightstoneBusinessDirectorResponse()
        {
            Directors = Enumerable.Empty<IProvideDirector>();
        }

        private LightstoneBusinessDirectorResponse(string message)
        {
            Directors = Enumerable.Empty<IProvideDirector>();
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static LightstoneBusinessDirectorResponse Empty()
        {
            return new LightstoneBusinessDirectorResponse();
        }

        public static LightstoneBusinessDirectorResponse Failure(string message)
        {
            return new LightstoneBusinessDirectorResponse(message);
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
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }


        [DataMember]
        public IAmLightstoneBusinessDirectorRequest Request { get; private set; }
      
    }
}
