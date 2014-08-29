namespace PackageBuilder.Domain.Contracts.Cqrs
{
    public interface IHandler<T>
    {
        void Handle(T message);
    }
}