﻿using System.Data;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLightstoneDirectorResponse
    {
        public static System.Data.DataSet ReturnDirectorReport()
        {
            var dt = new DataTable("director");
            dt.Columns.Add("ID");
            dt.Columns.Add("DirectorID");
            dt.Columns.Add("CompanyID");
            dt.Columns.Add("CompanyRegNumber");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("Initials");
            dt.Columns.Add("Surname");
            dt.Columns.Add("SurnameParticular");
            dt.Columns.Add("PreviousSurname");
            dt.Columns.Add("IdNumber");
            dt.Columns.Add("BirthDate");
            dt.Columns.Add("DesignationCode");
            dt.Columns.Add("RsaResident");
            dt.Columns.Add("WithdrawPublic");
            dt.Columns.Add("CountryCode");
            dt.Columns.Add("TypeCode");
            dt.Columns.Add("StatusCode");
            dt.Columns.Add("StatusDate");
            dt.Columns.Add("RegisterNumber");
            dt.Columns.Add("ExecutorName");
            dt.Columns.Add("ExecutorAppointDate");
            dt.Columns.Add("TrusteeName");
            dt.Columns.Add("FormLodgeDate");
            dt.Columns.Add("FormReceiveDate");
            dt.Columns.Add("FoundingStatementDate");
            dt.Columns.Add("MemberSize");
            dt.Columns.Add("MemberContribution");
            dt.Columns.Add("MemberContributionType");
            dt.Columns.Add("Excl_Con");
            dt.Columns.Add("RegisteredAddress1");
            dt.Columns.Add("RegisteredAddress2");
            dt.Columns.Add("RegisteredAddress3");
            dt.Columns.Add("RegisteredAddress4");
            dt.Columns.Add("RegisteredPostCode");
            dt.Columns.Add("ResidentialAddress1");
            dt.Columns.Add("ResidentialAddress2");
            dt.Columns.Add("ResidentialAddress3");
            dt.Columns.Add("ResidentialAddress4");
            dt.Columns.Add("ResidentialPostCode");
            dt.Columns.Add("BusinessAddress1");
            dt.Columns.Add("BusinessAddress2");
            dt.Columns.Add("BusinessAddress3");
            dt.Columns.Add("BusinessAddress4");
            dt.Columns.Add("BusinessPostCode");
            dt.Columns.Add("PostalAddress1");
            dt.Columns.Add("PostalAddress2");
            dt.Columns.Add("PostalAddress3");
            dt.Columns.Add("PostalAddress4");
            dt.Columns.Add("PostalPostCode");
            dt.Columns.Add("OccupationCode");
            dt.Columns.Add("FineExpiryDate");
            dt.Columns.Add("NatureOfChange");
            dt.Columns.Add("NationalityCode");
            dt.Columns.Add("Profession");
            dt.Columns.Add("ResignationDate");
            dt.Columns.Add("Estate");
            dt.Columns.Add("LSID");
            dt.Columns.Add("statusorder");

            var row = dt.NewRow();
            row["ID"] = 15697295;
            row["DirectorID"] = 1669624;
            row["CompanyID"] = 3206619;
            row["CompanyRegNumber"] = "2009/202656/23";
            row["FirstName"] = "MURRAY GRANT";
            row["Initials"] = "M G";
            row["Surname"] = "WOOLFSON";
            row["SurnameParticular"] = null;
            row["PreviousSurname"] = null;
            row["IdNumber"] = "7902065199085";
            row["BirthDate"] = "1979/02/06";
            row["DesignationCode"] = null;
            row["RsaResident"] = null;
            row["WithdrawPublic"] = false;
            row["CountryCode"] = null;
            row["TypeCode"] = "M";
            row["StatusCode"] = "A";
            row["StatusDate"] = null;
            row["RegisterNumber"] = null;
            row["ExecutorName"] = null;
            row["ExecutorAppointDate"] = null;
            row["TrusteeName"] = null;
            row["FormLodgeDate"] = null;
            row["FormReceiveDate"] = "2009/11/03";
            row["FoundingStatementDate"] = null;
            row["MemberSize"] = "100";
            row["MemberContribution"] = 100;
            row["MemberContributionType"] = 100;
            row["Excl_Con"] = 0;
            row["RegisteredAddress1"] = null;
            row["RegisteredAddress2"] = null;
            row["RegisteredAddress3"] = null;
            row["RegisteredAddress4"] = null;
            row["RegisteredPostCode"] = null;
            row["ResidentialAddress1"] = "48 BELLAIRS VIEW";
            row["ResidentialAddress2"] = "137 BELLAIRS DRIVE";
            row["ResidentialAddress3"] = "NORTHRIDING";
            row["ResidentialAddress4"] = null;
            row["ResidentialPostCode"] = 2169;
            row["BusinessAddress1"] = null;
            row["BusinessAddress2"] = null;
            row["BusinessAddress3"] = null;
            row["BusinessAddress4"] = null;
            row["BusinessPostCode"] = null;
            row["PostalAddress1"] = "P O BOX 501";
            row["PostalAddress2"] = "DOUGLASDALE";
            row["PostalAddress3"] = null;
            row["PostalAddress4"] = null;
            row["PostalPostCode"] = 2165;
            row["OccupationCode"] = null;
            row["FineExpiryDate"] = null;
            row["NatureOfChange"] = null;
            row["NationalityCode"] = null;
            row["Profession"] = null;
            row["ResignationDate"] = "1899/12/30";
            row["Estate"] = null;
            row["LSID"] = 1669624;
            row["statusorder"] = 0;

            dt.Rows.Add(row);
            var dataset = new DataSet();
            dataset.Tables.Add(dt);
            return dataset;
        }
    }
}