using PackageBuilder.Domain.Commands;

namespace PackageBuilder.Domain.Contracts.Cqrs
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}