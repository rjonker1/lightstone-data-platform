﻿using System.Collections.Generic;

namespace Lace.Models.Lightstone
{
    public interface IAddValuationItem
    {
        void AddImageGauages(IEnumerable<IRespondWithImageGaugeModel> model);
        void AddAccidentDistribution(IEnumerable<IRespondWithAccidentDistributionModel> model);
        void AddAmortisedValues(IEnumerable<IRespondWithAmortisedValueModel> model);
        void AddAreaFactors(IEnumerable<IRespondWithAreaFactorModel> model);
        void AddAuctionFactors(IEnumerable<IRespondWithAuctionFactorModel> model);
        void AddRepairIndex(IEnumerable<IRespondWithRepairIndexModel> model);
        void AddTotalSalesByAge(IEnumerable<IRespondWithTotalSalesByAgeModel> model);
        void AddTotalSalesByGender(IEnumerable<IRespondWithTotalSalesByGenderModel> model);
        void AddEstimatedValue(IEnumerable<IRespondWithEstimatedValueModel> model);
        void AddLastFiveSales(IEnumerable<IRespondWithSaleModel> model);
    }
}
