using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class RgtResponse
    {
        public Lace.Domain.Core.Entities.RgtResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.RgtResponse("", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
               "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
