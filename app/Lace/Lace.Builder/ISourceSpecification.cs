using System;
using System.Collections.Generic;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder
{
    public interface ISourceSpecification
    {
        IDictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> Specifications { get; }
    }
}
