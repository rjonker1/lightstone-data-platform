using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class EstimatedValueModel : IRespondWithEstimatedValueModel
    {
        public EstimatedValueModel(string estimatedValue, string estimatedLow, string estimatedHigh,
            string confidenceValue, string confidenceLevel)
        {
            EstimatedValue = estimatedValue;
            EstimatedLow = estimatedLow;
            EstimatedHigh = estimatedHigh;
            ConfidenceLevel = confidenceLevel;
            ConfidenceValue = confidenceValue;
        }

        [DataMember]
        public string EstimatedValue { get; private set; }
        [DataMember]
        public string EstimatedLow { get; private set; }
        [DataMember]
        public string EstimatedHigh { get; private set; }
        [DataMember]
        public string ConfidenceValue { get; private set; }
        [DataMember]
        public string ConfidenceLevel { get; private set; }
    }
}
