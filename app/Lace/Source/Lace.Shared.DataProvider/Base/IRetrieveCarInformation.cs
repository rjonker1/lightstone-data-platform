using Lace.Toolbox.Database.Models;

namespace Lace.Toolbox.Database.Base
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
