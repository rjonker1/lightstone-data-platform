using Lace.Request;
using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Cars
{
    public interface IRetrieveCarInformation
    {
        bool IsSatisfied { get; }
        CarInfo CarInformation { get; }
        ILaceRequestCarInformation CarInformationRequest { get; }
        IRetrieveCarInformation SetupDataSources();
        IRetrieveCarInformation BuildCarInformation();
        IRetrieveCarInformation GenerateData();
        IRetrieveCarInformation BuildCarInformationRequest();
    }
}
