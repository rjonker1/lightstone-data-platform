using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class IvidTitleHolderResponse
    {
        public Lace.Domain.Core.Entities.IvidTitleHolderResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.IvidTitleHolderResponse();
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}
