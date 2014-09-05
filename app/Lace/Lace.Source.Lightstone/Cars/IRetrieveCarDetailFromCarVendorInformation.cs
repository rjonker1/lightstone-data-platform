using System.Collections.Generic;
using Lace.Models.Lightstone;

namespace Lace.Source.Lightstone.Cars
{
    public interface IRetrieveCarDetailFromCarVendorInformation
    {
        bool IsSatisfied { get; }
        IEnumerable<IRespondWithCarModel> CarModels { get; }
        IRetrieveCarDetailFromCarVendorInformation SetupDataSources();
        IRetrieveCarDetailFromCarVendorInformation GenerateData();
        IRetrieveCarDetailFromCarVendorInformation BuildCarModels();
    }
}
