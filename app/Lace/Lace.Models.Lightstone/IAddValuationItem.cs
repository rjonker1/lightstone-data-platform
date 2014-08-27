using System.Collections.Generic;

namespace Lace.Models.Lightstone
{
    public interface IAddValuationItem
    {
        void AddImageGauages(IEnumerable<IRespondWithImageGaugeModel> model);
        void AddAccidentDistribution(IEnumerable<IRespondWithAccidentDistributionModel> model);
    }
}
