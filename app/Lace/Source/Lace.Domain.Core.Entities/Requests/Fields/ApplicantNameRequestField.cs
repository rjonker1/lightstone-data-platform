using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests.Fields
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