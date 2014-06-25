using System;
using Lace.Builder;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceChain : IBuildSourceChain
    {
        public void Default(DataPlatform.Shared.Entities.IAction action)
        {
            SourceChain = new FakeSourceSpecification().LicenseNumberRequestSpecification();
        }

        public Action<Request.ILaceRequest, Events.ILaceEvent, Response.ILaceResponse> SourceChain { get; private set; }
    }
}
