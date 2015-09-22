namespace Toolbox.Emailing.Domain
{
    public interface IBuildMessage
    {
        object Build(object command);
    }

    public interface IBuildMessage<in T, out TResult> : IBuildMessage
    {
        TResult Build(T command);
    }
}
