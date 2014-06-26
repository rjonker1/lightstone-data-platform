﻿namespace DataPlatform.Shared.Entities
{
    public interface IRolePermission : IEntity, IExpirable
    {
        IRole Role { get; set; }
        IAction Action { get; set; }
    }
}