using System;
using System.Collections.Generic;
using Lace.Source.Lightstone.Models;

namespace Lace.Test.Helper.Mothers.Sources.Lightstone
{
    public class SaleData
    {
        public static IEnumerable<Sale> CarSalesForCarId_107483()
        {
            return new List<Sale>()
            {
                new Sale(1038604, 107483, 2008, Convert.ToDateTime("Oct 25 2013  3:27PM"), false, 99990.00M, 0),
                new Sale(1039398, 107483, 2008, Convert.ToDateTime("Oct 23 2013 11:57AM"), false, 104995.00M, 15),
                new Sale(1016420, 107483, 2008, Convert.ToDateTime("Oct  7 2013  1:28PM"), false, 105950.00M, 18),
                new Sale(1027032, 107483, 2008, Convert.ToDateTime("Oct  1 2013  3:12PM"), false, 101000.01M, 31),
                new Sale(1028503, 107483, 2008, Convert.ToDateTime("Sep 30 2013  7:10PM"), false, 97000.00M, 40),
            };
        }
    }
}
