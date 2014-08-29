﻿using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Contracts;
using PackageBuilder.Domain.Contracts.Enitities;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestActionRepository : NamedCannedRepository<IAction>, IActionRepository
    {
         
    }
}