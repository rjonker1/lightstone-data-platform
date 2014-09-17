using System;

namespace PackageBuilder.Domain.Helpers.Cqrs.CommandHandling
{
    public abstract class Command
    {
        public Guid Id { get; set; }
        public void CreateAggregateRootId()
        {
            if (Id != Guid.Empty)
                throw new ApplicationException("AggregateRootId cannot be overwritten.");
            Id = Guid.NewGuid();
        }
    }
}