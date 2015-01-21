﻿using System;

namespace PackageBuilder.Core.Commands
{
    public abstract class DomainCommand : IDomainCommand
    {
        public Guid Id { get; private set; }

        protected DomainCommand(Guid id)
        {
            Id = id;
        }
    }
}
