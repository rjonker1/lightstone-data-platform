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
                new Sale(365893, 107483, 2008, Convert.ToDateTime("Jul 30 2014 12:00AM"), false, 98900.00M, 108),
                new Sale(588404, 107483, 2008, Convert.ToDateTime("Jul 22 2014 12:00AM"), false, 86800.00M, 56),
                new Sale(363812, 107483, 2008, Convert.ToDateTime("Jul 15 2014 12:00AM"), false, 93900.00M, 33),
                new Sale(555644, 107483, 2008, Convert.ToDateTime("Jul 15 2014 12:00AM"), false, 100320.00M, 15),
                new Sale(587943, 107483, 2008, Convert.ToDateTime("Jul 14 2014 12:00AM"), false, 96990.00M, 30),
            };
        }
    }
}
