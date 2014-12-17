﻿using PackageBuilder.Core.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IContract : INamedEntity, IEntity
    {
       ICustomer Customer { get; }
    }
}