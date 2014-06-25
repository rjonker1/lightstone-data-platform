using System.Collections.Generic;
using Lace.Response.ExternalServices;

namespace Lace
{
    public interface IBootstrap
    {
        IList<LaceExternalServiceResponse> LaceResponses { get; }
        void Execute();
        //event EventHandler<SetHandlersEventArgs> SetHandlers;
        //event EventHandler<LoadEventArgs> Load;
    }
}