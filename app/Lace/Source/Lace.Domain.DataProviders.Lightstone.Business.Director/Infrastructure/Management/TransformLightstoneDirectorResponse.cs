using System.Data;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Extensions;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management
{
    public class TransformLightstoneDirectorResponse : ITransformResponseFromDataProvider
    {
        public DataSet Response { get; private set; }
        public IProvideDataFromLightstoneBusinessDirector Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformLightstoneDirectorResponse(DataSet response)
        {
            Response = response;
            Continue = Response != null && Response.Tables.Count > 0;
        }

        public void Transform()
        {
            var results = Response.Tables["director"]
                .AsEnumerable()
                .Select(
                    s =>
                        new DirectorResponse(s.GetIntRowValue("ID"), s.GetIntRowValue("DirectorID"), s.GetIntRowValue("CompanyID"), s.GetStringValue("CompanyRegNumber"), s.GetStringValue("FirstName"), s.GetStringValue("Initials"),
                            s.GetStringValue("Surname"), s.GetStringValue("SurnameParticular"), s.GetStringValue("PreviousSurname"), s.GetStringValue("IdNumber"), s.GetStringValue("BirthDate"), s.GetStringValue("DesignationCode"),
                            s.GetStringValue("RsaResident"), s.GetStringValue("WithdrawPublic"), s.GetStringValue("CountryCode"), s.GetStringValue("TypeCode"), s.GetStringValue("StatusCode"), s.GetStringValue("StatusDate"),
                            s.GetStringValue("RegisterNumber"), s.GetStringValue("ExecutorName"), s.GetStringValue("ExecutorAppointDate"), s.GetStringValue("TrusteeName"), s.GetStringValue("FormLodgeDate"), s.GetStringValue("FormReceiveDate"),
                            s.GetStringValue("FoundingStatementDate"), s.GetDoubleRowValue("MemberSize"), s.GetDoubleRowValue("MemberContribution"), s.GetStringValue("MemberContributionType"), s.GetIntRowValue("Excl_Con"), s.GetStringValue("OccupationCode"),
                            s.GetStringValue("FineExpiryDate"), s.GetStringValue("NatureOfChange"), s.GetStringValue("NationalityCode"), s.GetStringValue("Profession"), s.GetStringValue("ResignationDate"), s.GetStringValue("Estate"), s.GetIntRowValue("LSID"),
                            s.GetIntRowValue("statusorder")
                            ).SetBusinessAddress(s.GetStringValue("BusinessAddress1"),s.GetStringValue("BusinessAddress2"),s.GetStringValue("BusinessAddress3"),s.GetStringValue("BusinessAddress4"),s.GetStringValue("BusinessPostCode"))
                            .SetPostalAddress(s.GetStringValue("PostalAddress1"),s.GetStringValue("PostalAddress2"),s.GetStringValue("PostalAddress3"),s.GetStringValue("PostalAddress4"),s.GetStringValue("PostalPostCode"))
                            .SetRegisteredAddress(s.GetStringValue("RegisteredAddress1"),s.GetStringValue("RegisteredAddress2"),s.GetStringValue("RegisteredAddress3"),s.GetStringValue("RegisteredAddress4"),s.GetStringValue("RegisteredPostCode"))
                            .SetResidentialAddress(s.GetStringValue("ResidentialAddress1"), s.GetStringValue("ResidentialAddress2"), s.GetStringValue("ResidentialAddress3"), s.GetStringValue("ResidentialAddress4"), s.GetStringValue("ResidentialPostCode"))
                            );

            Result = new LightstoneBusinessDirectorResponse(results);
        }
    }
}