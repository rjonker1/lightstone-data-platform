using System;
using Lace.Events;
using Lace.Models;
using Lace.Request;

namespace Lace.Builder
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, ILaceEvent, IProvideLaceResponse> SourceChain { get; }
    }
}
