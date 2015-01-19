using Lace.CrossCutting.DataProviderCommandSource.Car.Core.Models;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.CrossCutting.DataProviderCommandSource.Car.Core.Contracts
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
