using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class CarTypeDataBuilder
    {
        public static IEnumerable<CarType> ForCarTypes()
        {
            return Mothers.Sources.Lightstone.CarTypeData.CarTypes();
        }
    }
}
