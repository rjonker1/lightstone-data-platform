﻿namespace DataPlatform.Shared.Entities
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
    }
}