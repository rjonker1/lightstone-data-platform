using Lace.Toolbox.Database.Dtos;

namespace Lace.Toolbox.Database.Base
{ 
    public interface IRetrieveCarInformation
    {
        bool IsSatisfied { get; }
        CarInformationDto CarInformationDto { get; }
        IHaveCarInformation CarInformationRequest { get; }
       // IRetrieveCarInformation SetupDataSources();
        IRetrieveCarInformation BuildCarInformation();
        IRetrieveCarInformation GenerateData();
        IRetrieveCarInformation BuildCarInformationRequest();
    }
}
