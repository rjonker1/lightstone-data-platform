using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class DataProviderIdentifier
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public decimal CostPrice { get; private set; }

        [DataMember]
        public decimal RecommendedPrice { get; private set; }

        [DataMember]
        public DataProviderAction Action { get; private set; }

        [DataMember]
        public DataProviderState State { get; private set; }

        public DataProviderIdentifier()
        {
        }

        public DataProviderIdentifier(int id, string name, decimal costPrice, decimal recommendedPrice,
            DataProviderAction action, DataProviderState state)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
            Action = action;
            State = state;
        }
    }
}
