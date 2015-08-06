using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class EstimatedValueModel : IRespondWithEstimatedValueModel
    {
        public void SetTradeEstimatedValues(string tradeEstimatedValue, string tradeEstimatedLow,
            string tradeEstimatedHigh,
            string tradeConfidenceValue, string tradeConfidenceLevel)
        {

            TradeEstimatedValue = tradeEstimatedValue;
            TradeEstimatedHigh = tradeEstimatedHigh;
            TradeEstimatedLow = tradeEstimatedLow;
            TradeConfidenceValue = tradeConfidenceValue;
            TradeConfidenceLevel = tradeConfidenceLevel;
        }

        public void SetRetailEstimatedValues(string retailEstimatedValue, string retailEstimatedLow,
            string retailEstimatedHigh,
            string retailConfidenceValue, string retailConfidenceLevel)
        {
            RetailEstimatedValue = retailEstimatedValue;
            RetailEstimatedLow = retailEstimatedLow;
            RetailEstimatedHigh = retailEstimatedHigh;
            RetailConfidenceLevel = retailConfidenceLevel;
            RetailConfidenceValue = retailConfidenceValue;
        }

        public void SetAuctionEstimatedValues(string auctionEstimate)
        {
            AuctionEstimate = auctionEstimate;
        }

        [DataMember]
        public string RetailEstimatedValue { get; private set; }

        [DataMember]
        public string RetailEstimatedLow { get; private set; }

        [DataMember]
        public string RetailEstimatedHigh { get; private set; }

        [DataMember]
        public string RetailConfidenceValue { get; private set; }

        [DataMember]
        public string RetailConfidenceLevel { get; private set; }

        [DataMember]
        public string TradeEstimatedValue { get; set; }

        [DataMember]
        public string TradeEstimatedLow { get; set; }

        [DataMember]
        public string TradeEstimatedHigh { get; set; }

        [DataMember]
        public string TradeConfidenceValue { get; set; }

        [DataMember]
        public string TradeConfidenceLevel { get; set; }

        [DataMember]
        public string AuctionEstimate { get; set; }

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
    }
}
