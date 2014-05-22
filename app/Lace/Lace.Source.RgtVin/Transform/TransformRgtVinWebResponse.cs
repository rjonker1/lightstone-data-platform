using System;
using System.Data;
using Lace.Models.RgtVin.Dto;

namespace Lace.Source.RgtVin.Transform
{
    public class TransformRgtVinWebResponse : ITransform
    {
        private readonly DataTable _carDetailTable;

        public RgtVinResponse Result { get; private set; }
        public bool Continue { get; private set; }


        public TransformRgtVinWebResponse(DataSet response)
        {
            Continue = response != null;
            Result = Continue ? new RgtVinResponse() : null;

            _carDetailTable = response != null ? response.Tables["CarDetail"] : new DataTable();
        }

        public void Transform()
        {
            Result.Colour = GetDataValue(_carDetailTable, 0, "COLOUR");
            Result.Month = ValidateNumber(GetDataValue(_carDetailTable, 0, "MONTH"));
            Result.Price = ValidateNumber(GetDataValue(_carDetailTable, 0, "PRICE"));
            Result.Quarter = ValidateNumber(GetDataValue(_carDetailTable, 0, "QTR"));
            Result.RgtCode = ValidateNumber(GetDataValue(_carDetailTable, 0, "RGTCODE"));
            Result.VehicleMake = GetDataValue(_carDetailTable, 0, "MAKE");
            Result.VehicleModel = GetDataValue(_carDetailTable, 0, "MODEL");
            Result.VehicleType = GetDataValue(_carDetailTable, 0, "TYPE");
            Result.Vin = GetDataValue(_carDetailTable, 0, "VIN");
            Result.Year = ValidateNumber(GetDataValue(_carDetailTable, 0, "YEAR"));
        }

        private static int ValidateNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return 0;

            int num;

            int.TryParse(number, out num);

            return num;
        }

        private static string GetDataValue(DataTable table, int row, string column)
        {
            string result = null;
            if (row >= 0 && row < table.Rows.Count)
            {
                result = Convert.ToString(table.Rows[row][column]);
            }
            return result;
        }
    }
}
