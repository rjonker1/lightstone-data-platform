using System;
using DataPlatform.Shared.Entities;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder
{
    public interface IBuildSourceChain
    {
        void Default(IAction action);

      //  IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> SourceChain { get; }

        Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; }
    }
}
