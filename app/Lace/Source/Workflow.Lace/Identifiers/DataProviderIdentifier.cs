using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;

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
        public DataProviderResponseState State { get; private set; }

        [DataMember]
        public DataProviderNoRecordState BillNoRecords { get; private set; }

        public DataProviderIdentifier()
        {
        }

        public DataProviderIdentifier(int id, string name, decimal costPrice, decimal recommendedPrice,
            DataProviderAction action, DataProviderResponseState state, DataProviderNoRecordState billNoRecords)
        {
            Id = id;
            Name = name;
            CostPrice = costPrice;
            RecommendedPrice = recommendedPrice;
            Action = action;
            State = state;
            BillNoRecords = billNoRecords;
        }

        public DataProviderIdentifier(DataProviderCommandSource dataProvider,
            DataProviderAction action, DataProviderResponseState state, DataProviderNoRecordState billNoRecords)
        {
            Id = (int) dataProvider;
            Name = dataProvider.ToString();
            Action = action;
            State = state;
            BillNoRecords = billNoRecords;
        }

        public DataProviderIdentifier SetPrice(IAmDataProvider dataProvider)
        {
            CostPrice = dataProvider == null ? 0 : dataProvider.CostPrice;
            RecommendedPrice = dataProvider == null ? 0 : dataProvider.RecommendedPrice;
            return this;
        }
    }
}
