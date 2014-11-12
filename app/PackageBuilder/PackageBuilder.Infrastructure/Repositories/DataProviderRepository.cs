﻿using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class DataProviderRepository : Repository<DataProvider>, IDataProviderRepository
    {
        public DataProviderRepository(ISession session) : base(session)
        {
        }

        public bool Exists(Guid id, DataProviderName name)
        {
            return this.FirstOrDefault(x => x.DataProviderId != id && x.Name == name) != null;
        }
    }
}