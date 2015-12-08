using System;
using Lim.Core;

namespace Lim
{
    public class Command : IMessage
    {
        public Guid AggregateId { get; set; }
        public Guid User { get; set; }
    }
}
