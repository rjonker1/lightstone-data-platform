namespace Lim.Core
{
    public interface IFail
    {
        bool Fail(object command);
    }

    public interface IFail<in T> : IFail
    {
        bool Fail(T command);
    }
}
