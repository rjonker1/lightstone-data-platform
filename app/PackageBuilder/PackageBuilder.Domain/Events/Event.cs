using System;
using PackageBuilder.Domain.Contracts.Cqrs;

namespace PackageBuilder.Domain.Events
{
    public class Event : IMessage
    {
        public Guid Id; 
        public int Version;
    }
}