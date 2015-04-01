using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.CrossCutting.DataProvider.Car.Core.Contracts
{
    public interface IRetrieveCarInformation
    {
        bool IsSatisfied { get; }
        CarInfo CarInformation { get; }
        IHaveCarInformation CarInformationRequest { get; }
        IRetrieveCarInformation SetupDataSources();
        IRetrieveCarInformation BuildCarInformation();
        IRetrieveCarInformation GenerateData();
        IRetrieveCarInformation BuildCarInformationRequest();
    }
}
