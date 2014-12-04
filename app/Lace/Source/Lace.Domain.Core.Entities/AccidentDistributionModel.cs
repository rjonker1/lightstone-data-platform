using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    public class AccidentDistributionModel : IRespondWithAccidentDistributionModel
    {
        public AccidentDistributionModel(string band, double value)
        {
            Band = band;
            Value = value;
        }

        public string Band
        {
            get;
            private set;
        }

        public double Value
        {
            get;
            private set;
        }
    }
}
