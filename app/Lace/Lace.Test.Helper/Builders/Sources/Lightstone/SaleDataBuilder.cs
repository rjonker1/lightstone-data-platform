using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class SaleDataBuilder
    {
        public static IEnumerable<Sale> ForCarSalesOnCarId_107483()
        {
            return Mothers.Sources.Lightstone.SaleData.CarSalesForCarId_107483();
        }
    }
}
