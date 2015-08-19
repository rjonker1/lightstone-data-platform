using Lace.Domain.Core.Contracts.Requests;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class PCubedFicaVerficationResponse
    {
        public IPointToLaceProvider DefaultFicaResponse()
        {
            var ezScore =
                new Lace.Domain.Core.Entities.PCubedFicaVerficationResponse();

            return ezScore;
        } 
    }
}
