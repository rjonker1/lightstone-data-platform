using System;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; }
    }
}
