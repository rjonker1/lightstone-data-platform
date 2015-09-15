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
    }
}
