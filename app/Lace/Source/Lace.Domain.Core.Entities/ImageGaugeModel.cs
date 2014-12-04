using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    public class ImageGaugeModel : IRespondWithImageGaugeModel
    {
        public ImageGaugeModel(double? minValue, double? maxValue, double? value, double? quarter, string gaugeName)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
            Quarter = quarter;
            GaugeName = gaugeName;
        }

        public double? MinValue
        {
            get;
            private set;
        }

        public double? MaxValue
        {
            get;
            private set;
        }

        public double? Value
        {
            get;
            private set;
        }

        public double? Quarter
        {
            get;
            private set;
        }

        public string GaugeName
        {
            get;
            private set;
        }
    }
}
