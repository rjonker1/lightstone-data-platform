using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IRetrieveCarInformation
    {
        bool IsSatisfied { get; }
        CarInformation CarInformation { get; }
        IHaveCarInformation CarInformationRequest { get; }
        IRetrieveCarInformation SetupDataSources();
        IRetrieveCarInformation BuildCarInformation();
        IRetrieveCarInformation GenerateData();
        IRetrieveCarInformation BuildCarInformationRequest();
    }
}
