using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class PCubedEzScoreResponse
    {
        public IPointToLaceProvider DefaultEzScoreResponse()
        {
            var ezScore =
                new Lace.Domain.Core.Entities.PCubedEzScoreResponse(new List<IRespondWithEzScore>()
                {
                    new EzScoreRecord().WithHeader("","","","","","","","","").WithDetail("","","","","","","","","","","","","","","","","","","","","","")
                });

            return ezScore;
        } 
    }
}
