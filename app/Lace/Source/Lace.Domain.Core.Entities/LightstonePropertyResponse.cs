using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstonePropertyResponse : IProvideDataFromLightstoneProperty
    {
        public LightstonePropertyResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            PropertyInformation = Enumerable.Empty<IRespondWithProperty>();
        }

        public static LightstonePropertyResponse Empty()
        {
            return new LightstonePropertyResponse();
        }

        public LightstonePropertyResponse(IEnumerable<IRespondWithProperty> properties)
        {
            PropertyInformation = properties;
        }

        private LightstonePropertyResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            PropertyInformation = Enumerable.Empty<IRespondWithProperty>();
        }

        public static LightstonePropertyResponse WithState(DataProviderResponseState state)
        {
            return new LightstonePropertyResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }

        [DataMember]
        public string ResponseStateMessage
        {
            get { return ResponseState.Description(); }
        }

        [DataMember]
        public IAmLightstonePropertyRequest Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithProperty> PropertyInformation { get; private set; }

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