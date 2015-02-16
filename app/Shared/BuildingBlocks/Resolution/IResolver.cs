using System;
using System.Collections.Generic;

namespace Shared.Resolution
{
    public interface IResolver
    {
        DefaultResolver Register<TType>(Func<TType> creation);
        TType Resolve<TType>() where TType : class;
        IEnumerable<TType> ResolveAll<TType>() where TType : class;
    }
}