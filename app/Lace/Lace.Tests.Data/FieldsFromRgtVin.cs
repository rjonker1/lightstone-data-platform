using Lace.Request;

namespace Lace.Tests.Data
{
    public class VehicleMakeField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "VehicleMake";
            }
        }
    }

    public class ColourField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "Colour";
            }
        }
    }

    public class PriceField : IField
    {
        public int SourceId
        {
            get
            {
                return 3;
            }
        }

        public string Name
        {
            get
            {
                return "Price";
            }
        }
    }
}
