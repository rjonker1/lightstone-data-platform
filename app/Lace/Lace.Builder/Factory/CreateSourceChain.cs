using System;
using System.Collections.Generic;
using DataPlatform.Shared.Public.Entities;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder.Factory
{
    public class CreateSourceChain
    {
        public static IDictionary<Type, Func<ILaceRequest, ILaceEvent, ILaceResponse>> Default(ILaceRequest request)
        {
            
        }
    }
}
