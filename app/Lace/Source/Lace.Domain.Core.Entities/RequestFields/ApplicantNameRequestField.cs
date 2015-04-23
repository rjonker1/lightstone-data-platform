using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Entities.RequestFields
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