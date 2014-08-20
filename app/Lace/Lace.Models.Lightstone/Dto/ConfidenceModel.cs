﻿namespace Lace.Models.Lightstone.Dto
{
    public class ConfidenceModel : IRespondWithConfidenceModel
    {

        public ConfidenceModel(string carType, int year, double value)
        {
            CarType = carType;
            Year = year;
            Value = value;
        }


        public string CarType
        {
            get;
            private set;
        }

        public int Year
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