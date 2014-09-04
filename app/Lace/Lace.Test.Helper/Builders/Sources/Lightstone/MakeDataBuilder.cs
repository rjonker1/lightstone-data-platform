using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MakeDataBuilder
    {
        public static IEnumerable<Make> ForAllMakes()
        {
            return Mothers.Sources.Lightstone.MakeData.ForAllMakes();
        }
    }
}
