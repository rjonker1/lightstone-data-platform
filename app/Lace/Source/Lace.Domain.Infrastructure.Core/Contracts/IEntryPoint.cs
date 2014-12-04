using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IEntryPoint
    {
        IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request);
    }
}
