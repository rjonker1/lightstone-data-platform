using System;
using Lace.Events;
using Lace.Models.Responses;
using Lace.Request;

namespace Lace.Builder
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; }
    }
}
