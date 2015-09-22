namespace Toolbox.Emailing.Domain
{
    public abstract class AbstractMessageBuilder<T, TResult> : IBuildMessage<T, TResult>
    {
        public abstract TResult Build(T command);

        public object Build(object command)
        {
            return Build((T) command);
        }
    }
}
