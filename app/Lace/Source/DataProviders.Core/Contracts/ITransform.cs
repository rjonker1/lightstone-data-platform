namespace Lace.Domain.DataProviders.Core.Contracts
{
    public interface ITransform
    {
        bool Continue { get; }
        void Transform();
    }

    //public abstract class AbstractTransformer<T, TResult> : ITransform<T, TResult>
    //{
    //    public abstract TResult Transform(T response);
    //    public object Transform(object response)
    //    {
    //        return Transform((T) response);
    //    }
    //    public bool Continue { get; protected set; }
    //}

    //public interface ITransform
    //{
    //    bool Continue { get; }
    //    object Transform(object response);
    //}

    //public interface ITransform<in T, out TResult> : ITransform
    //{
    //    TResult Transform(T response);
    //}
}
