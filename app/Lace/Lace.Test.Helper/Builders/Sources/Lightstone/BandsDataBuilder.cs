using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class BandsDataBuilder
    {
        public static IEnumerable<Band> ForAllBands()
        {
            return Mothers.Sources.Lightstone.BandData.AllBands();
        }
    }
}
