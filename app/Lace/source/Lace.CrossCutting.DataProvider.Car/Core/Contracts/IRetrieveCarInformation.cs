using Lace.Toolbox.Database.Models;

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
