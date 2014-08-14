namespace Lace.Models.Lightstone.Dto
{
    public class AreaFactorModel : IRespondWithAreaFactorModel
    {
        public AreaFactorModel(string muncipality, int index, double value)
        {
            Municipality = muncipality;
            Index = index;
            Value = value;
        }

        public string Municipality
        {
            get;
            private set;
        }

        public int Index
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
