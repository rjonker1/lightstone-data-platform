using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Models.RequestFields
{
    public class RegistrationNumberFinder : AbstractRequestFieldFinder
    {
        public RegistrationNumberFinder()
            : base(RequestFieldType.RegisterNumber)
        {

        }

        public RegistrationNumberFinder(IFindRequestField next)
            : base(next, RequestFieldType.RegisterNumber)
        {

        }
    }
}
