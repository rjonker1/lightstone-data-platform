using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessDirectorResponse : IProvideDataFromLightstoneBusinessDirector
    {
        public LightstoneBusinessDirectorResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            Directors = Enumerable.Empty<IProvideDirector>();
        }

        public static LightstoneBusinessDirectorResponse Empty()
        {
            return new LightstoneBusinessDirectorResponse();
        }

        public LightstoneBusinessDirectorResponse(IEnumerable<IProvideDirector> directors)
        {
            Directors = directors;
        }

        private LightstoneBusinessDirectorResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            Directors = Enumerable.Empty<IProvideDirector>();
        }

        public static LightstoneBusinessDirectorResponse WithState(DataProviderResponseState state)
        {
            return new LightstoneBusinessDirectorResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }

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
