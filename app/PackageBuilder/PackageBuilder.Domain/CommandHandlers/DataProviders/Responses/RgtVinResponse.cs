using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class RgtVinResponse
    {
        public Lace.Domain.Core.Entities.RgtVinResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.RgtVinResponse("", 0, 0, 0, 0, "", "", "", "", 0);
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
