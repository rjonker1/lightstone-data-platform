using System;

namespace Lace.Source
{
    public interface ITransformToLaceType<T, TResult> : ITransform where TResult : new()
    {
        T Message { get; }

        TResult Result { get; }
    }
}
