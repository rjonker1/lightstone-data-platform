﻿using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetSales
    {
        IEnumerable<Sale> Sales { get; }
        void GetSales(IHaveCarInformation request);
    }
}
