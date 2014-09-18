using System.Collections.Generic;
using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.DataObject
{
    public class Valuation : IRespondWithValuation
    {
        public Valuation()
        {
            AmortisationFactors = new List<AmortisationFactorModel>();
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

        public IEnumerable<IRespondWithAmortisationFactorModel> AmortisationFactors { get; private set; }

        public IEnumerable<IRespondWithAreaFactorModel> AreaFactors { get; private set; }

        public IEnumerable<IRespondWithAuctionFactorModel> AuctionFactors { get; private set; }

        public IEnumerable<IRespondWithAccidentDistributionModel> AccidentDistribution { get; private set; }

        public IEnumerable<IRespondWithRepairIndexModel> RepairIndex { get; private set; }

        public IEnumerable<IRespondWithTotalSalesByAgeModel> TotalSalesByAge { get; private set; }

        public IEnumerable<IRespondWithTotalSalesByGenderModel> TotalSalesByGender { get; private set; }

        public IEnumerable<IRespondWithEstimatedValueModel> EstimatedValue { get; private set; }

        public IEnumerable<IRespondWithSaleModel> LastFiveSales { get; private set; }

        public IEnumerable<IRespondWithPriceModel> Prices { get; private set; }

        public IEnumerable<IRespondWithFrequencyModel> Frequency { get; private set; }

        public IEnumerable<IRespondWithConfidenceModel> Confidence { get; private set; }

        public IEnumerable<IRespondWithAmortisedValueModel> AmortisedValues { get; private set; }

        public IEnumerable<IRespondWithImageGaugeModel> ImageGauges { get; private set; }
    }
}
