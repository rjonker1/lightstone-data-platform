using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class IvidResponse
    {
        public Lace.Domain.Core.Entities.IvidResponse Default()
        {
            var ivid = new Lace.Domain.Core.Entities.IvidResponse();
            ivid.BuildSpecificInformation();
            ivid.AddResponseState(DataProviderResponseState.NoRecords);
            return ivid;
        }
    }
}