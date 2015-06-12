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
                            s.GetStringValue("FoundingStatementDate"), s.GetDoubleRowValue("MemberSize"), s.GetDoubleRowValue("MemberContribution"), s.GetStringValue("MemberContributionType"), s.GetStringValue("Excl_Con"), s.GetStringValue("OccupationCode"),
                            s.GetStringValue("FineExpiryDate"), s.GetStringValue("NatureOfChange"),s.GetStringValue()
                            ));

            Result = new LightstoneBusinessDirectorResponse(results);
        }
    }
}