using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Cars
{
    public interface IRetrieveCarInformation
    {
        bool IsSatisfied { get; }
        CarInfo CarInformation { get; }
        IProvideCarInformationForRequest CarInformationRequest { get; }
        IRetrieveCarInformation SetupDataSources();
        IRetrieveCarInformation BuildCarInformation();
        IRetrieveCarInformation GenerateData();
        IRetrieveCarInformation BuildCarInformationRequest();
    }
}
