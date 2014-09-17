using System.Collections.Generic;
using Lace.Response.ExternalServices;

namespace Lace
{
    public interface IBootstrap
    {
        IList<LaceExternalSourceResponse> LaceResponses { get; }
        void Execute();
    }
}