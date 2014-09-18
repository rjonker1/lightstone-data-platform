using System.Data;
using Lace.Models.RgtVin.DataObject;
using DataSet = System.Data.DataSet;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeRgtVinResponse
    {
        public static RgtVinResponse GetRgtVinResponseForLicensePlateNumber()
        {
            return new RgtVinResponse("Super White II", 8, 100000, 4, 107483, "TOYOTA", "Auris 1.6 RT 5-dr", "Auris",
                "SB1KV58E40F039277", 2008);
        }

        public static DataSet GetRgtVinWebResponseForLicensePlateNumber()
        {
            var ds = new DataSet();
            var dt = new DataTable("CarDetail");
            dt.Columns.Add("COLOUR");
            dt.Columns.Add("MONTH");
            dt.Columns.Add("PRICE");
            dt.Columns.Add("QTR");
            dt.Columns.Add("RGTCODE");
            dt.Columns.Add("MAKE");
            dt.Columns.Add("MODEL");
            dt.Columns.Add("TYPE");
            dt.Columns.Add("VIN");
            dt.Columns.Add("YEAR");


            var row = dt.NewRow();
            row["COLOUR"] = "Super White II";

            row["MONTH"] = "8";

            row["PRICE"] = "100000";

            row["QTR"] = "3";

            row["RGTCODE"] = "107483";

            row["MAKE"] = "TOYOTA";

            row["MODEL"] = "Auris 1.6 RT 5-dr";

            row["TYPE"] = "Auris";

            row["VIN"] = "SB1KV58E40F039277";

            row["YEAR"] = "2008";

            dt.Rows.Add(row);

            ds.Tables.Add(dt);

            return ds;
        }
    }
}
