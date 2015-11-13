using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class PCubedFicaVerficationResponse
    {
        public IPointToLaceProvider Default()
        {
            var pCubed =
                new Lace.Domain.Core.Entities.PCubedFicaVerficationResponse();
            pCubed.AddResponseState(DataProviderResponseState.NoRecords);
            return pCubed;
        } 
    }
}
