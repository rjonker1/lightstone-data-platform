using Lace.Toolbox.Database.Base;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public interface IDetermineRequestType
    {
        IRetrieveCarInformation Retrieve();
    }

}
