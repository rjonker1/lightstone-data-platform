using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.Dto
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
