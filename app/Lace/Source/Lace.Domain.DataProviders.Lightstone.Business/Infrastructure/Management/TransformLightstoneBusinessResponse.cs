using System.Data;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Extensions;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management
{
    public class TransformLightstoneBusinessResponse : ITransformResponseFromDataProvider
    {
        public DataSet Response { get; private set; }
        public IProvideDataFromLightstoneBusinessCompany Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformLightstoneBusinessResponse(DataSet response)
        {
            Response = response;
            Continue = Response != null && Response.Tables.Count > 0;
        }

        public void Transform()
        {
            var results = Response.Tables["company"]
                .AsEnumerable()
                .Select(
                    s =>
                        new CompanyResponse(s.GetIntRowValue("ID"), s.GetStringValue("EnterpriseType"), s.GetStringValue("ShortenType"),
                            s.GetStringValue("CompanyRegNumber"), s.GetStringValue("OldRegistrationNumber"),
                            s.GetStringValue("TypeDate"), s.GetStringValue("CompanyName"), s.GetStringValue("ShortName"),
                            s.GetStringValue("TranslatedName"), s.GetStringValue("RegistrationDate"), s.GetStringValue("BusinessStartDate"),
                            s.GetStringValue("WithdrawnPublic"), s.GetStringValue("StatusCode"), s.GetStringValue("StatusDate"),
                            s.GetStringValue("SicCode"), s.GetStringValue("FinancialYearEnd"), s.GetStringValue("FinancialEffectiveDate"))
                            .SetPhysicalAddress(s.GetStringValue("PhysicalAddress1"), s.GetStringValue("PhysicalAddress2"),
                                s.GetStringValue("PhysicalAddress3"), s.GetStringValue("PhysicalAddress4"), s.GetStringValue("PhysicalPostCode")
                                , s.GetStringValue("CountryCode"), s.GetStringValue("CountryOfOrigin"), s.GetStringValue("RegionCode"))
                            .SetPostalAddress(s.GetStringValue("PostalAddress1"), s.GetStringValue("PostalAddress2"),
                                s.GetStringValue("PostalAddress3"), s.GetStringValue("PostalAddress4"), s.GetStringValue("PostalPostCode"))
                            .SetCompanyDetail(s.GetDoubleRowValue("AuthorisedCapital"), s.GetDoubleRowValue("AuthorisedShares"),
                                s.GetDoubleRowValue("IssuedCapital"), s.GetDoubleRowValue("IssuedShares"), s.GetStringValue("FormReceivedDate"),
                                s.GetStringValue("FormDate"), s.GetStringValue("ConversionNumber"), s.GetStringValue("TaxNumber"),
                                s.GetBoolRowValue("CPA"), s.GetStringValue("StatusCodeDesc"), s.GetStringValue("RegionCodeDesc"),
                                s.GetStringValue("SIC_Description")));

            Result = new LightstoneBusinessCompanyResponse(results);
        }
    }
}