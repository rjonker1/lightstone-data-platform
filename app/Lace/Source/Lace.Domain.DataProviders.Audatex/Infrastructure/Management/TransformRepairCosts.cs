using System;
using System.Collections.Generic;
using System.Linq;

namespace Lace.Source.Audatex.Transform
{
    public class TransformRepairCosts
    {
        private const string DefaultResult = "Not Available";
        private const string Sign = "to";

        public static string Transform(decimal? repairCost)
        {
            var result = DefaultResult;
            var bands = new List<CostBand>()
            {
                new CostBand(null, 10000, false, false),
                new CostBand(10000, 20000, true, false),
                new CostBand(20000, 30000, true, false),
                new CostBand(30000, 40000, true, false),
                new CostBand(40000, 50000, true, false),
                new CostBand(50000, 60000, true, false),
                new CostBand(60000, 70000, true, false),
                new CostBand(70000, 80000, true, false),
                new CostBand(80000, 90000, true, false),
                new CostBand(90000, 100000, true, false),
                new CostBand(100000, 110000, true, false),
                new CostBand(110000, 120000, true, false),
                new CostBand(120000, 130000, true, false),
                new CostBand(130000, 140000, true, false),
                new CostBand(140000, 150000, true, false),
                new CostBand(150000, null, true, false)
            };

            if (!repairCost.HasValue) return result;


            var band = bands.FirstOrDefault(b => b.Contains(repairCost.Value));

            if (band == null) return result;

            if (band.IsUnaryBoundary)
            {
                result = ToRepairCostBand(repairCost.Value, band.UnaryBoundary.Value);
            }
            else if (band.IsBinaryBoundary)
            {
                result = ToRepairCostBand(repairCost.Value, band.Item1.Value, band.Item2.Value);
            }

            return result;
        }

        private static string ToRepairCostBand(decimal amount, decimal threshold)
        {
            var result = string.Empty;
            var sign = '=';

            if (amount > threshold)
            {
                sign = '>';
            }
            else if (amount < threshold)
            {
                sign = '<';
            }

            result = string.Format("{0} {1:C}", sign, threshold);
            result = result.Replace(".", ",");
            return result;
        }

        private static string ToRepairCostBand(decimal amount, decimal low, decimal high)
        {
            var result = string.Empty;

            result = string.Format("{1:C} {0} {2:C}", Sign, low, high);
            result = result.Replace(".", ",");
            return result;
        }

        private class CostBand : Tuple<decimal?, decimal?>
        {
            public CostBand(decimal? item1, decimal? item2, bool lowInclusive, bool highInclusive)
                : base(item1, item2)
            {
                LowInclusive = lowInclusive;
                HighInclusive = highInclusive;
            }

            private bool LowInclusive { get; set; }
            private bool HighInclusive { get; set; }

            public bool IsBinaryBoundary
            {
                get { return Item1.HasValue && Item2.HasValue; }
            }

            public bool IsUnaryBoundary
            {
                get { return (Item1.HasValue && !Item2.HasValue) || (Item2.HasValue && !Item1.HasValue); }
            }

            public decimal? UnaryBoundary
            {
                get
                {
                    var result = Item1;
                    if (Item2.HasValue)
                    {
                        result = Item2;
                    }
                    return result;
                }
            }


            public bool Contains(decimal amount)
            {
                var result = IsBinaryBoundary;

                if (Item1.HasValue)
                {
                    if (LowInclusive)
                    {
                        result = amount >= Item1.Value;
                    }
                    else
                    {
                        result = amount > Item1.Value;
                    }
                }
                else
                {
                    result = true;
                }

                if (Item2.HasValue)
                {
                    if (HighInclusive)
                    {
                        result = result && (amount <= Item2.Value);
                    }
                    else
                    {
                        result = result && (amount < Item2.Value);
                    }
                }


                return result;
            }
        }
    }
}
