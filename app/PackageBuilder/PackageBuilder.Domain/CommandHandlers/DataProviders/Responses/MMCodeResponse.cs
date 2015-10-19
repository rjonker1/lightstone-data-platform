using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class MMCodeResponse
    {
        public Lace.Domain.Core.Entities.MMCodeResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.MMCodeResponse(0,0,"");
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
