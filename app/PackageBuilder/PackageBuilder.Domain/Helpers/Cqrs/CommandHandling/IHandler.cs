namespace PackageBuilder.Domain.Helpers.Cqrs.CommandHandling
{
    public interface IHandler<T>
    {
        void Handle(T message);
    }
}