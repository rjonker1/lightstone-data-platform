using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class Valuation : IRespondWithValuation
    {
        public Valuation()
        {
            //AmortisationFactors = new List<AmortisationFactorModel>();
            AreaFactors = new List<AreaFactorModel>();
            AuctionFactors = new List<AuctionFactorModel>();
            AccidentDistribution = new List<AccidentDistributionModel>();
            RepairIndex = new List<RepairIndexModel>();
            TotalSalesByAge = new List<TotalSalesByAgeModel>();
            TotalSalesByGender = new List<TotalSalesByGenderModel>();
            Prices = new List<PriceModel>();
            Frequency = new List<FrequencyModel>();
            Confidence = new List<ConfidenceModel>();
            AmortisedValues = new List<AmortisedValueModel>();
            ImageGauges = new List<ImageGaugeModel>();
            EstimatedValue = new List<EstimatedValueModel>();
            LastFiveSales = new List<SaleModel>();
        }

        //public void AddAmortisationFactors(IEnumerable<IRespondWithAmortisationFactorModel> model)
        //{
        //    AmortisationFactors = model;
        //}

        public void AddPrices(IEnumerable<IRespondWithPriceModel> model)
        {
            Prices = model;
        }

        public void AddFrequency(IEnumerable<IRespondWithFrequencyModel> model)
        {
            Frequency = model;
        }

        public void AddConfidence(IEnumerable<IRespondWithConfidenceModel> model)
        {
            Confidence = model;
        }

        public void AddImageGauages(IEnumerable<IRespondWithImageGaugeModel> model)
        {
            ImageGauges = model;
        }

        public void AddAccidentDistribution(IEnumerable<IRespondWithAccidentDistributionModel> model)
        {
            AccidentDistribution = model;
        }

        public void AddAmortisedValues(IEnumerable<IRespondWithAmortisedValueModel> model)
        {
            AmortisedValues = model;
        }

        public void AddAreaFactors(IEnumerable<IRespondWithAreaFactorModel> model)
        {
            AreaFactors = model;
        }

        public void AddAuctionFactors(IEnumerable<IRespondWithAuctionFactorModel> model)
        {
            AuctionFactors = model;
        }

        public void AddRepairIndex(IEnumerable<IRespondWithRepairIndexModel> model)
        {
            RepairIndex = model;
        }

        public void AddTotalSalesByAge(IEnumerable<IRespondWithTotalSalesByAgeModel> model)
        {
            TotalSalesByAge = model;
        }

        public void AddTotalSalesByGender(IEnumerable<IRespondWithTotalSalesByGenderModel> model)
        {
            TotalSalesByGender = model;
        }

        public void AddEstimatedValue(IEnumerable<IRespondWithEstimatedValueModel> model)
        {
            EstimatedValue = model;
        }

        public void AddLastFiveSales(IEnumerable<IRespondWithSaleModel> model)
        {
            LastFiveSales = model;
        }

        //[DataMember]
        //public IEnumerable<IRespondWithAmortisationFactorModel> AmortisationFactors { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithAreaFactorModel> AreaFactors { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithAuctionFactorModel> AuctionFactors { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithAccidentDistributionModel> AccidentDistribution { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithRepairIndexModel> RepairIndex { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithTotalSalesByAgeModel> TotalSalesByAge { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithTotalSalesByGenderModel> TotalSalesByGender { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithEstimatedValueModel> EstimatedValue { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithSaleModel> LastFiveSales { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithPriceModel> Prices { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithFrequencyModel> Frequency { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithConfidenceModel> Confidence { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithAmortisedValueModel> AmortisedValues { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithImageGaugeModel> ImageGauges { get; private set; }
        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
