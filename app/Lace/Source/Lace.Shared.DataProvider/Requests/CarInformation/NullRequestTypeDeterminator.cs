using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Domain;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public class NullRequestTypeDeterminator : IDetermineRequestType
    {
        public IRetrieveCarInformation Retrieve()
        {
            return GetCarInformation.Empty();
        }
    }
}
