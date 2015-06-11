using System;
using System.Data;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Extensions
{
    public static class DataRowExtensions
    {
        public static string GetStringValue(this DataRow row, string value)
        {
            return row[value].ToString();
        }

        public static decimal GetDecimalRowValue(this DataRow row, string value)
        {
            decimal @decimal;
            return decimal.TryParse(row[value].ToString(), out @decimal) ? @decimal : 0;
        }

        public static long GetLongRowValue(this DataRow row, string value)
        {
            long @long;
            return long.TryParse(row[value].ToString(), out @long) ? @long : 0;
        }

        public static int GetIntRowValue(this DataRow row, string value)
        {
            int @int;
            return int.TryParse(row[value].ToString(), out @int) ? @int : 0;
        }

        public static Guid GetGuidRowValue(this DataRow row, string value)
        {
            Guid @guid;
            return Guid.TryParse(row[value].ToString(), out @guid) ? @guid : Guid.Empty;
        }

        public static double GetDoubleRowValue(this DataRow row, string value)
        {
            double @double;
            return double.TryParse(row[value].ToString(), out @double) ? @double : 0.0;
        }

        public static bool GetBoolRowValue(this DataRow row, string value)
        {
            bool @bool;
            return bool.TryParse(row[value].ToString(), out @bool) ? @bool : false;
        }
    }
}