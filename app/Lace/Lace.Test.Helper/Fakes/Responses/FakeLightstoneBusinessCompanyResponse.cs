using System.Data;
using Lace.Domain.DataProviders.Lightstone.Business.Company.LightstoneBusinessServiceReference;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLightstoneBusinessCompanyResponse
    {
        public static System.Data.DataSet ReturnCompanyReport()
        {

            var dt = new DataTable("company");
            dt.Columns.Add("ID");
            dt.Columns.Add("EnterpriseType");
            dt.Columns.Add("ShortenType");
            dt.Columns.Add("CompanyRegNumber");
            dt.Columns.Add("OldRegistrationNumber");
            dt.Columns.Add("TypeDate");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("ShortName");
            dt.Columns.Add("TranslatedName");
            dt.Columns.Add("RegistrationDate");
            dt.Columns.Add("BusinessStartDate");
            dt.Columns.Add("WithdrawnPublic");
            dt.Columns.Add("StatusCode");
            dt.Columns.Add("StatusDate");
            dt.Columns.Add("SicCode");
            dt.Columns.Add("FinancialYearEnd");
            dt.Columns.Add("FinancialEffectiveDate");
            dt.Columns.Add("PhysicalAddress1");
            dt.Columns.Add("PhysicalAddress2");
            dt.Columns.Add("PhysicalAddress3");
            dt.Columns.Add("PhysicalAddress4");
            dt.Columns.Add("PhysicalPostCode");
            dt.Columns.Add("PostalAddress1");
            dt.Columns.Add("PostalAddress2");
            dt.Columns.Add("PostalAddress3");
            dt.Columns.Add("PostalAddress4");
            dt.Columns.Add("PostalPostCode");
            dt.Columns.Add("CountryCode");
            dt.Columns.Add("CountryOfOrigin");
            dt.Columns.Add("RegionCode");
            dt.Columns.Add("AuthorisedCapital");
            dt.Columns.Add("AuthorisedShares");
            dt.Columns.Add("IssuedCapital");
            dt.Columns.Add("IssuedShares");
            dt.Columns.Add("FormReceivedDate");
            dt.Columns.Add("FormDate");
            dt.Columns.Add("ConversionNumber");
            dt.Columns.Add("TaxNumber");
            dt.Columns.Add("CPA");
            dt.Columns.Add("StatusCodeDesc");
            dt.Columns.Add("RegionCodeDesc");
            dt.Columns.Add("SIC_Description");

            var row = dt.NewRow();
            row["ID"] = 3479505;
            row["EnterpriseType"] = "Private Company (Pty) Ltd)";
            row["ShortenType"] = "(Pty) Ltd";
            row["CompanyRegNumber"] = "2010/018608/07";
            row["CompanyName"] = "LIGHTSTONE AUTO";
            row["ShortName"] = null;
            row["TranslatedName"] = null;
            row["RegistrationDate"] = "2010/09/09";
            row["BusinessStartDate"] = "2010/09/09";
            row["WithdrawnPublic"] = false;
            row["StatusCode"] = "03";
            row["StatusDate"] = null;
            row["SicCode"] = null;
            row["FinancialYearEnd"] = 2;
            row["FinancialEffectiveDate"] = "2010/09/09";
            row["PhysicalAddress1"] = "FERN GLEN FERNRIDGE OFFICE PARK";
            row["PhysicalAddress2"] = "5 HUNTER STREET";
            row["PhysicalAddress3"] = "FERNDALE";
            row["PhysicalAddress4"] = null;
            row["PhysicalPostCode"] = 2194;
            row["PostalAddress1"] = "P O BOX 418";
            row["PostalAddress2"] = "PINEGOWRIE";
            row["PostalAddress3"] = null;
            row["PostalAddress4"] = null;
            row["PostalPostCode"] = 2123;
            row["CountryCode"] = null;
            row["CountryOfOrigin"] = null;
            row["RegionCode"] = 7;
            row["AuthorisedCapital"] = 1000;
            row["AuthorisedShares"] = 1000;
            row["IssuedCapital"] = 100;
            row["IssuedShares"] = 100;
            row["FormReceivedDate"] = null;
            row["FormDate"] = null;
            row["ConversionNumber"] = null;
            row["TaxNumber"] = 9853212158;
            row["StatusCodeDesc"] = "In Business";
            row["RegionCodeDesc"] = "Gauteng";
            dt.Rows.Add(row);
            var dataset = new DataSet();
            dataset.Tables.Add(dt);
            return dataset;


//            <company diffgr:id="company1" msdata:rowOrder="0">
//<ID>3479505</ID>
//<EnterpriseType>Private Company (Pty) Ltd)</EnterpriseType>
//<ShortenType>(Pty) Ltd</ShortenType>
//<CompanyRegNumber>2010/018608/07</CompanyRegNumber>
//<CompanyName>LIGHTSTONE AUTO</CompanyName>
//<ShortName/>
//<TranslatedName/>
//<RegistrationDate>2010/09/09</RegistrationDate>
//<BusinessStartDate>2010/09/09</BusinessStartDate>
//<WithdrawnPublic>False</WithdrawnPublic>
//<StatusCode>03</StatusCode>
//<StatusDate/>
//<SicCode/>
//<FinancialYearEnd>2</FinancialYearEnd>
//<FinancialEffectiveDate>2010/09/09</FinancialEffectiveDate>
//<PhysicalAddress1>FERN GLEN FERNRIDGE OFFICE PARK</PhysicalAddress1>
//<PhysicalAddress2>5 HUNTER STREET</PhysicalAddress2>
//<PhysicalAddress3>FERNDALE</PhysicalAddress3>
//<PhysicalAddress4/>
//<PhysicalPostCode>2194</PhysicalPostCode>
//<PostalAddress1>P O BOX 418</PostalAddress1>
//<PostalAddress2>PINEGOWRIE</PostalAddress2>
//<PostalAddress3/>
//<PostalAddress4/>
//<PostalPostCode>2123</PostalPostCode>
//<CountryCode/>
//<CountryOfOrigin/>
//<RegionCode>7</RegionCode>
//<AuthorisedCapital>1000</AuthorisedCapital>
//<AuthorisedShares>1000</AuthorisedShares>
//<IssuedCapital>100</IssuedCapital>
//<IssuedShares>100</IssuedShares>
//<FormReceivedDate/>
//<FormDate/>
//<ConversionNumber/>
//<TaxNumber>9853212158</TaxNumber>
//<StatusCodeDesc>In Business</StatusCodeDesc>
//<RegionCodeDesc>Gauteng</RegionCodeDesc>
//</company>
        }

        public static reportTrans ConfirmCompany()
        {
            return new reportTrans();
//            <reportTrans xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://lightstonebusiness.co.za/">
//<paid>true</paid>
//<report_guid>1b03a54d-c758-430d-b551-86ab4086ec4b</report_guid>
//</reportTrans>
        }

        public static System.Data.DataSet ReturnCompanies()
        {
            return new DataSet();

//            <DataSet xmlns="http://lightstonebusiness.co.za/">
//<xs:schema xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" id="NewDataSet">
//<xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
//<xs:complexType>
//<xs:choice minOccurs="0" maxOccurs="unbounded">
//<xs:element name="companies">
//<xs:complexType>
//<xs:sequence>
//<xs:element name="companyid" type="xs:int" minOccurs="0"/>
//<xs:element name="companyname" type="xs:string" minOccurs="0"/>
//<xs:element name="companyregnumber" type="xs:string" minOccurs="0"/>
//<xs:element name="VatNo" type="xs:string" minOccurs="0"/>
//<xs:element name="StatusCode" type="xs:string" minOccurs="0"/>
//</xs:sequence>
//</xs:complexType>
//</xs:element>
//</xs:choice>
//</xs:complexType>
//</xs:element>
//</xs:schema>
//<diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
//<NewDataSet xmlns="">
//<companies diffgr:id="companies1" msdata:rowOrder="0">
//<companyid>3479505</companyid>
//<companyname>LIGHTSTONE AUTO</companyname>
//<companyregnumber>2010/018608/07</companyregnumber>
//<VatNo>4740259769</VatNo>
//<StatusCode>03</StatusCode>
//</companies>
//</NewDataSet>
//</diffgr:diffgram>
//</DataSet>
        }
    }
}
