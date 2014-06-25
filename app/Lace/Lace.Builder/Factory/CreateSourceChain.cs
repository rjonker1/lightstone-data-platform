using System;
using DataPlatform.Shared.Entities;
using Lace.Builder.Specifications;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        public void Default(IAction action)
        {
            SourceChain = new SourceSpecification().LicenseNumberRequestSpecification();
        }

        public Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; private set; }
    }

}
