﻿namespace Lace.Models.Lightstone.Dto
{
    public class AreaFactorModel : IRespondWithAreaFactorModel
    {
        public AreaFactorModel(string muncipality, double value)
        {
            Municipality = muncipality;
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
