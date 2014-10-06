using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IEntryPoint
    {
        IList<LaceExternalSourceResponse> GetResponsesFromLace(ILaceRequest request);
    }
}
