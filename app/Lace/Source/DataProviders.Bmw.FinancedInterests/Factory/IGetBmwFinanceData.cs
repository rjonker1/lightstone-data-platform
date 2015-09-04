﻿using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Bmw.Finance.Factory
{
    public interface IGetBmwFinanceData
    {
        IEnumerable<BmwFinance> Get(object worker, object request, object responseFactory);
    }

    public interface IGetBmwFinanceData<in T1, in T2, in T3> : IGetBmwFinanceData
    {
        IEnumerable<BmwFinance> Get(T1 worker, T2 request, T3 responseFactory);
    }


}
