using PackageBuilder.Domain.Contracts.Cqrs;

namespace PackageBuilder.Domain.Events
{
    public class Event : IMessage
    {
        public int Version;
    }
}