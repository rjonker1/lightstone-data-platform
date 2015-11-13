using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstoneConsumerSpecificationsResponse : IProvideDataFromLightstoneConsumerSpecifications
    {
        public LightstoneConsumerSpecificationsResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            RepairData = new List<IRespondWithRepairData>();
        }

        public static LightstoneConsumerSpecificationsResponse Empty()
        {
            return new LightstoneConsumerSpecificationsResponse();
        }

        public LightstoneConsumerSpecificationsResponse(IEnumerable<IRespondWithRepairData> repairData)
        {
            RepairData = repairData;
        }
        private LightstoneConsumerSpecificationsResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            RepairData = new List<IRespondWithRepairData>();
        }

        public static LightstoneConsumerSpecificationsResponse WithState(DataProviderResponseState state)
        {
            return new LightstoneConsumerSpecificationsResponse(state);
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
        public IEnumerable<IRespondWithRepairData> RepairData { get; private set; }

        [DataMember]
        public IAmLightstoneConsumerSpecificationsRequest Request { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
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