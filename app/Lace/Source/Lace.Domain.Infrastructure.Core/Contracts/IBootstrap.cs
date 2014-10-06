using System.Collections.Generic;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBootstrap
    {
        IList<LaceExternalSourceResponse> LaceResponses { get; }
        void Execute();
    }
}