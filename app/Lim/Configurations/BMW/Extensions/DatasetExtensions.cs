using System;
using System.Data;

namespace Toolbox.Bmw.Extensions
{
    public static class DatasetExtensions
    {
        public static string GetString(this DataRow row, string value)
        {
            return row[value].ToString();
        }

        public static int GetInt(this DataRow row, string value)
        {
            int @int;
            return int.TryParse(row[value].ToString(), out @int) ? @int : 0;
        }

        public static DateTime GetDate(this DataRow row, string value)
        {
            DateTime @date;
            return DateTime.TryParse(row[value].ToString(), out @date) ? @date : new DateTime(1753, 1, 1);
        }
    }
}
