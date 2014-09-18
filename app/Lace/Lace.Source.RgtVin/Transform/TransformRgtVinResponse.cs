using System.Data;
using Lace.Extensions;
using Lace.Models.RgtVin.DataObject;

namespace Lace.Source.RgtVin.Transform
{
    public class TransformRgtVinResponse : ITransform
    {
        private readonly DataTable _carDetailTable;

        public RgtVinResponse Result { get; private set; }
        public bool Continue { get; private set; }


        public TransformRgtVinResponse(DataSet response)
        {
            Continue = response != null;
            Result = Continue ? new RgtVinResponse() : null;

            _carDetailTable = response != null ? response.Tables["CarDetail"] : new DataTable();
        }

        public void Transform()
        {
            Result.BuidWithValidation(_carDetailTable.ValueFromTableRow(0, "COLOUR"),
                _carDetailTable.ValueFromTableRow(0, "MONTH"),
                _carDetailTable.ValueFromTableRow(0, "PRICE"),
                _carDetailTable.ValueFromTableRow(0, "QTR"),
                _carDetailTable.ValueFromTableRow(0, "RGTCODE"),
                _carDetailTable.ValueFromTableRow(0, "MAKE"),
                _carDetailTable.ValueFromTableRow(0, "MODEL"),
                _carDetailTable.ValueFromTableRow(0, "TYPE"),
                _carDetailTable.ValueFromTableRow(0, "VIN"),
                _carDetailTable.ValueFromTableRow(0, "YEAR")
                );
            Result.SetCarName();
        }
    }
}
