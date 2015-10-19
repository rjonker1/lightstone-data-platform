using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Bmw.Finance.Factory
{
    public interface IGetBmwFinanceData
    {
        IEnumerable<BmwFinanceDto> Get(object query, object request, object responseFactory);
    }

    public interface IGetBmwFinanceData<in T1, in T2, in T3> : IGetBmwFinanceData
    {
        IEnumerable<BmwFinanceDto> Get(T1 query, T2 request, T3 responseFactory);
    }


}
