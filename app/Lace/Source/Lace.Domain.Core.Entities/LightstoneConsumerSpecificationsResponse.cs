using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class LightstoneConsumerSpecificationsResponse : IProvideDataFromLightstoneConsumerSpecifications
    {
        public LightstoneConsumerSpecificationsResponse()
        {
            RepairData = new List<IRespondWithRepairData>();
        }

        private LightstoneConsumerSpecificationsResponse(string message)
        {
            RepairData = new List<IRespondWithRepairData>();
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static LightstoneConsumerSpecificationsResponse Empty()
        {
            return new LightstoneConsumerSpecificationsResponse();
        }

        public static LightstoneConsumerSpecificationsResponse Failure(string message)
        {
            return new LightstoneConsumerSpecificationsResponse(message);
        }

        public LightstoneConsumerSpecificationsResponse(IEnumerable<IRespondWithRepairData> repairData)
        {
            RepairData = repairData;
        }

        [DataMember]
        public IEnumerable<IRespondWithRepairData> RepairData { get; private set; }

        [DataMember]
        public IAmLightstoneConsumerSpecificationsRequest Request { get; private set; }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

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