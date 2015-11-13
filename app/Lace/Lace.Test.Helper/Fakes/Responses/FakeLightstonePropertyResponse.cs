using System.Data;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLightstonePropertyResponse
    {
        public static DataSet GetResponseFromReturnProperties()
        {
            var dt = new DataTable("Properties");
            dt.Columns.Add("sr_id");
            dt.Columns.Add("prop_id");
            dt.Columns.Add("DEED_ID");
            dt.Columns.Add("PROPTYPE_ID");
            dt.Columns.Add("property_type");
            dt.Columns.Add("PROVINCE");
            dt.Columns.Add("MUNICNAME");
            dt.Columns.Add("DEEDTOWN");
            dt.Columns.Add("ERF");
            dt.Columns.Add("PORTION");
            dt.Columns.Add("BUYER_NAME");
            dt.Columns.Add("FIRSTNAME");
            dt.Columns.Add("MIDDLENAME");
            dt.Columns.Add("SURNAME");
            dt.Columns.Add("PERSON_TYPE_ID");
            dt.Columns.Add("BUYER_IDCK");
            dt.Columns.Add("MUNIC_ID");
            dt.Columns.Add("PROV_ID");
            dt.Columns.Add("user_id");
            dt.Columns.Add("Size");
            dt.Columns.Add("X");
            dt.Columns.Add("Y");
            dt.Columns.Add("SUBURB");
            dt.Columns.Add("Registrar");
            dt.Columns.Add("Title_Deed_No");
            dt.Columns.Add("Reg_Date");
            dt.Columns.Add("TownShip");
            dt.Columns.Add("Purchase_Price");
            dt.Columns.Add("Purchase_Date");
            dt.Columns.Add("Bond_Number");
            dt.Columns.Add("Township_alt");
            dt.Columns.Add("RE");
            dt.Columns.Add("Active_Status");
            dt.Columns.Add("Estate_Name");
            dt.Columns.Add("est_id");
            dt.Columns.Add("sub_id");
            dt.Columns.Add("ReqStatus_ID");
            dt.Columns.Add("estimatedcad");

            var row = dt.NewRow();
            row["sr_id"] = 1;
            row["prop_id"] = 10226523;
            row["DEED_ID"] = 610;
            row["PROPTYPE_ID"] = 3;
            row["property_type"] = "FH";
            row["PROVINCE"] = "GA";
            row["MUNICNAME"] = "CITY OF JOHANNESBURG";
            row["DEEDTOWN"] = "MAROELADA";
            row["ERF"] = 448;
            row["PORTION"] = 0;
            row["BUYER_NAME"] = "WOOLFSON MURRAY GRANT";
            row["FIRSTNAME"] = "MURRAY";
            row["MIDDLENAME"] = "GRANT";
            row["SURNAME"] = "WOOLFSON";
            row["PERSON_TYPE_ID"] = "PP";
            row["BUYER_IDCK"] = 7902065199085;
            row["MUNIC_ID"] = 74;
            row["PROV_ID"] = 8;
            row["user_id"] = "5a7222e1-ee65-433b-b673-827319e89cbb";
            row["Size"] = 743;
            row["X"] = 27.985247;
            row["Y"] = -26.023466;
            row["SUBURB"] = "MAROELADAL";
            row["Registrar"] = "T";
            row["Title_Deed_No"] = "T37763/2012";
            row["Reg_Date"] = 20120530;
            row["TownShip"] = "MAROELADAL EXT 23";
            row["Purchase_Price"] = 2450000;
            row["Purchase_Date"] = 20120201;
            row["Bond_Number"] = "B22499/2012";
            row["Township_alt"] = "MAROELADAL EXT 23";
            row["RE"] = false;
            row["Active_Status"] = "Active";
            row["Estate_Name"] = "WATERFORD ESTATE";
            row["est_id"] = 196;
            row["sub_id"] = 7980;
            row["ReqStatus_ID"] = 1;
            row["estimatedcad"] = false;

            dt.Rows.Add(row);
            var dataset = new DataSet();
            dataset.Tables.Add(dt);
            return dataset;
        }
    }
}
