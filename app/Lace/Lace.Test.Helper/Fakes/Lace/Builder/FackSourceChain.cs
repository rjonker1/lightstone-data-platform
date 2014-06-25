using System;
using Lace.Builder;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FackSourceChain : IBuildSourceChain
    {
        public void Default(DataPlatform.Shared.Entities.IAction action)
        {
            throw new NotImplementedException();
        }

        public Action<Request.ILaceRequest, Events.ILaceEvent, Response.ILaceResponse> SourceChain { get; private set; }
    }
}
