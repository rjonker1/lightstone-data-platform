﻿using System.Collections.Generic;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IRole : IEntity, INamedEntity
    {
        IEnumerable<IRolePermission> RolePermissions { get; }
        IEnumerable<IAction> Actions { get; }
    }
}