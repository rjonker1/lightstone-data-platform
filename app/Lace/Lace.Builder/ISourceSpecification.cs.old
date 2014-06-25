using System;
using System.Collections.Generic;
using Lace.Builder.RequestTypes;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder
{
    public interface ISourceSpecification
    {
        IEnumerable<KeyValuePair<Type, Action<ILaceRequest, ILaceEvent, ILaceResponse>>> GetSpecificationForRequestType(
            IRequestType requestType);
    }
}
