using System.Collections.Generic;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

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
