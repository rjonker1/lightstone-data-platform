﻿using System;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.Packages.ReadModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(ISession session)
            : base(session)
        {
        }

        public bool Exists(Guid id, string name)
        {
            return this.FirstOrDefault(x => x.PackageId != id && x.Name.Trim().ToLower() == name.Trim().ToLower() && x.State.Name == StateName.Published) != null;
        }
    }
}