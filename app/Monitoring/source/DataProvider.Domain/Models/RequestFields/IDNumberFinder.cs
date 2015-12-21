using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Models.RequestFields
{
    public class IdNumberFinder :  AbstractRequestFieldFinder
    {
          public IdNumberFinder() : base(RequestFieldType.IdentityNumber)
        {

        }

          public IdNumberFinder(IFindRequestField next)
            : base(next, RequestFieldType.IdentityNumber)
        {

        }
    }
}