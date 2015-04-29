using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace PackageBuilder.Domain.Requests.Fields
{
    public class ApplicantNameRequestField : IAmApplicantNameRequestField
    {
        public string Field { get; private set; }

        public ApplicantNameRequestField(string field)
        {
            Field = field;
        }
    }
}