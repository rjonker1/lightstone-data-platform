using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.Dto
{
    public class RepairIndexModel : IRespondWithRepairIndexModel
    {
        public RepairIndexModel(int year, string band, double value)
        {
            Year = year;
            Band = band;
            Value = value;
        }

        public int Year
        {
            get;
            private set;
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
