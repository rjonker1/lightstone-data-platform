using System;

namespace PackageBuilder.Domain.Entities.States.Commands
{
    public class RenameState : CreateState
    {
        public RenameState(Guid id, string name)
            : base(id, name)
        {
        }
    }
}