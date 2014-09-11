using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class CarDataBuilder
    {
        public static IEnumerable<Car> ForCarsOnly()
        {
            return Mothers.Sources.Lightstone.CarData.ForCarOnly();
        }
    }
}
