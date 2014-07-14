using System;
using System.Data;

namespace Lace.Extensions
{
    public static class DataSetExtensions
    {
        public static string ValueFromTableRow(this DataTable table, int row, string column)
        {
            try
            {
                if (row >= 0 && row < table.Rows.Count)
                {
                    return Convert.ToString(table.Rows[row][column]);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}

